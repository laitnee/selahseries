const App = () => {
    AttachEventListeners();
};
//class Comment {
//    commentId;
//    parentId;
//    content;
//    createdAt;
//    author;
//    postId;
//    subComments;
//}
//const HandleComments = (response) => {
//    var commentList = response;
//    console.log("RESPONSE", response);
//};
//const fetchComments =  () => {
//    fetch(COMMENT_URL)
//        .then(response => response.json())
//        .then(HandleComments);
//};

const AttachEventListeners = () => {
    document.querySelectorAll("[data-CommentVisibility]").forEach((node, index) => {
        node.addEventListener("click", ToggleCommentVisibility);
    });
    document.querySelectorAll("[data-ReplyListener]").forEach((node, index) => {
        node.addEventListener("click", ReplyHandler);
    });
    
};

const ToggleCommentVisibility = (event) => {
    let commentToToggle = event.target.parentNode.parentNode.parentNode.nextElementSibling;
    if (commentToToggle.style.display === "none") {
        commentToToggle.style.display = "block";
        event.target.textContent = "Hide Replies";
    }
    else {
        commentToToggle.style.display = "none";
        event.target.textContent = "Show Replies";
    }
};
const ReplyHandler = (event) => {
    
    event.target.disabled = true;
    var commentParentId = event.target.attributes["data-ReplyListener"].value;
    console.log(commentParentId);
    var commentToReply = event.target.parentNode.nextSibling;
    var template = document.querySelector('#CommentBox');
    var clone = template.content.cloneNode(true);
    


    commentToReply.parentNode.insertBefore(clone, commentToReply.nextSibling.nextSibling);
    document.querySelector("[data-commentParent]").value = commentParentId;
    console.log(document.querySelector("#comment_reply_form"));   


};
document.addEventListener("DOMContentLoaded", App());