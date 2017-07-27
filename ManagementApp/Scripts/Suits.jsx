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

var DropDownOption = React.createClass({
    render: function () {
        var i = 0;
        return (
            <option key={i++} value={this.props.value}>{this.props.name}</option>
        )
    }
});


var CommentForm = React.createClass({
    getInitialState: function () {
        return { type: '', color: '', additionnalNote: '', colors: [], clothingTypes: [] };
    },

    loadColorsFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.colorsUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ colors: data });
        }.bind(this);
        xhr.send();
    },

    loadClothingTypesFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.clothingTypesUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ clothingTypes: data });
        }.bind(this);
        xhr.send();
    },

    componentDidMount: function () {
        this.loadColorsFromServer();
        this.loadClothingTypesFromServer();
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
        this.setState({ type: 1, color: 1, additionnalNote: '' });
    },
    render: function () {

        var colorNodes = this.state.colors.map(function (color) {
            return (
                <DropDownOption key={color.Id} value={color.Id} name={color.Name} />
            )
        });

        var clothingTypesNodes = this.state.clothingTypes.map(function (clothingType) {
            return (
                <DropDownOption key={clothingType.Id} value={clothingType.Id} name={clothingType.Name} />
            )
        });

        return (
            <form className="commentForm col-md-12" onSubmit={this.handleSubmit} >
                <div className="form-group row">
                    <label className="col-md-2 col-form-label">Type:</label>
                    <select onChange={this.handleTypeChange} value={this.state.type} className="form-control">
                        {clothingTypesNodes}
                    </select>
                </div>
                <div className="form-group row">
                    <label className="col-md-2 col-form-label">Color:</label>
                    <select onChange={this.handleColorChange} value={this.state.color} className="form-control col-md-12">
                        {colorNodes}
                    </select>
                </div>
                <div className="form-group row">
                    <label className="col-md-2 col-form-label"></label>
                    <textarea className="form-control col-md-12" type="text" placeholder="Additionnal Notes" value={this.state.additionnalNote} onChange={this.handleNoteChange}> </textarea>
                </div>
                <input type="submit" value="Create" className="btn btn-primary" />
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

                <h2>Add a new article: </h2>
                <CommentForm colorsUrl="/colors" clothingTypesUrl="/clothestypes" onClothesSubmit={this.handleCommentSubmit} />
            </div>
        );
    }
});

ReactDOM.render(
    <CommentBox url="/clothes" submitUrl="/clothes/new" pollInterval={2000} />,
    document.getElementById('content')
);