import './build/keditor.min.js';


const _keditor = KEDITOR.create("contentEditor", {
    showPathLabel: false,
    width: "auto",
    maxWidth: "100%",
    height: "auto",
    minHeight: "100px",
    maxHeight: "250px",
    buttonList: [
      ["undo", "redo", "font", "fontSize", "formatBlock"],
      [
        "bold",
        "underline",
        "italic",
        "strike",
        "subscript",
        "superscript",
        "removeFormat",
      ],
      
      [
        "fontColor",
        "hiliteColor",
        "outdent",
        "indent",
        "align",
        "horizontalRule",
        "list",
        "table",
      ],
      [
        "link",
        "image",
        "fullScreen",
        "showBlocks",
        "codeView",
        "preview",
        "print",
        "save",
      ],
    ],
    callBackSave: function (contents) {
        document.querySelector('#contentEditor').textContent = contents;
    },
});

$(document).ready(_keditor);