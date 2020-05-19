import './build/keditor.min.js';



const _keditor = KEDITOR.create("contentEditor", {
    showPathLabel: false,
    font: [
        'Work sans',
        'sans-serif',
        'ubuntu',
        'Georgia'
    ],
    fontSize: [
        8, 10, 14, 16, 18, 24, 36
    ],
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

        document.querySelector('#contentEditor').textContent = `<div style="text-shadow: rgba(0,0,0,.01) 0 0 1px; 
                            -webkit-font-smoothing: antialiased; - webkit - text - shadow: rgba(0, 0, 0, .01) 0 0 1px; 
                            line-height: 1.875; font-weight:500; color: rgba(0,0,0,0.8);"> `
                            + contents +
                            ' </div>';
    },
});

_keditor.onChange = (contents) => {
    document.querySelector('[data-command=save]').click();
};
$(document).ready(_keditor);