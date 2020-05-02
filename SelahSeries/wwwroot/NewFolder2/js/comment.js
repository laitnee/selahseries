const COMMENT_URL = "/comments/2";

const App = () => {
    fetchComments();
};
class Comment {
    commentId;
    parentId;
    content;
    createdAt;
    author;
    postId;
    subComments;
}
const HandleComments = (response) => {
    var commentList = response;
    console.log("RESPONSE", response);
};
const fetchComments =  () => {
    fetch(COMMENT_URL)
        .then(response => response.json())
        .then(HandleComments);
};

const postComments = () => {

};


document.addEventListener("DOMContentLoaded", App());