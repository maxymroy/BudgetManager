var ClothesList = React.createClass({
    render: function () {
        var commentNodes = this.props.data.map(function (comment) {
            return (
                <Comment type={comment.ClothesType} key={comment.Id} color={comment.Color}>
                    {comment.AdditionnalNote}
                </Comment>
            );
        });
        return (
            <div className="commentList">
                <table className="table">
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Color</th>
                            <th>Additionnal Note</th>
                        </tr>
                    </thead>
                    <tbody>
                        {commentNodes}
                    </tbody>
                </table>
            </div>
        );
    }
});


var CommentForm = React.createClass({
    getInitialState: function () {
        return { type: '', color: '', additionnalNote: '' };
    },
    handleTypeChange: function (e) {
        this.setState({ type: e.target.value });
    },
    handleColorChange: function (e) {
        this.setState({ color: e.target.value });
    },
    handleNoteChange: function (e) {
        this.setState({ additionnalNote: e.target.value });
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var type = this.state.type.trim();
        var color = this.state.color.trim();
        var note = this.state.additionnalNote.trim();
        if (!type || !color) {
            return;
        }
        this.props.onClothesSubmit({ ClothesType: type, Color: color, AdditionnalNote: note });
        this.setState({ type: '', color: '', additionnalNote: '' });
    },
    render: function () {
        return (
            <form className="commentForm col-md-12" onSubmit={this.handleSubmit} >
                <input className="form-control col-md-3" type="text" placeholder="Type" value={this.state.type} onChange={this.handleTypeChange} />
                <input className="form-control col-md-3" type="text" placeholder="Color" value={this.state.color} onChange={this.handleColorChange} />
                <input className="form-control col-md-3" type="text" placeholder="Additionnal Notes" value={this.state.additionnalNote} onChange={this.handleNoteChange} />
                <input type="submit" value="Create" className="btn btn-primary col-md-3" />
            </form>
        );
    }
});

var Comment = React.createClass({
    rawMarkup: function () {
        var md = new Remarkable();
        if (this.props.children != null) {
            var rawMarkup = md.render(this.props.children.toString());
        }
        else {
            var rawMarkup = "";
        }
        return { __html: rawMarkup };
    },

    render: function () {
        return (
            <tr className="comment">
                <td>
                    {this.props.type}
                </td>
                <td>
                    {this.props.color}
                </td>
                <td dangerouslySetInnerHTML={this.rawMarkup()} >
                </td>
            </tr>
        );
    }
});

var CommentBox = React.createClass({

    loadClothesFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },

    handleCommentSubmit: function (clothes) {
        var data = new FormData();
        data.append('ClothesType', clothes.ClothesType);
        data.append('Color', clothes.Color);
        data.append('AdditionnalNote', clothes.AdditionnalNote);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = function () {
            this.loadClothesFromServer();
        }.bind(this);
        xhr.send(data);
    },

    getInitialState: function () {
        return { data: [] };
    },
    componentDidMount: function () {
        this.loadClothesFromServer();
        window.setInterval(this.loadClothesFromServer, this.props.pollInterval);
    },
    render: function () {
        return (
            <div className="commentBox">
                <h1>Articles</h1>
                <ClothesList data={this.state.data} />
                <CommentForm onClothesSubmit={this.handleCommentSubmit} />
            </div>
        );
    }
});

ReactDOM.render(
    <CommentBox url="/clothes" submitUrl="/clothes/new" pollInterval={2000} />,
    document.getElementById('content')
);