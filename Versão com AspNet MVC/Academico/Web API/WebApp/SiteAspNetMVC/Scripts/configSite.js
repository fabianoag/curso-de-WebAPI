/* Para este exemplo será usado o mesmo formulario */
var cadastraModal = $("#cadastraModal");
var submitModal = $("#submitModal");
var tipoModal = $("#tipo");
var idModal = $("#Id");
var idModalDel = $("#IdDel");
var modalBodyDel = $('#modalBodyDel')
var cancelarModal = $('#cancelarModal');

var tiluloModal = $("#myModalTitulo");

cadastraModal.click(() => {
    tiluloModal.text("Cadastro do aluno");
    submitModal.text("Cadastra");
    tipoModal.val("cadastra");
});

function edit(id, nome, sobrenome, telefone, ra) {
    idModal.val(id);
    tipoModal.val("atualiza");
    tiluloModal.text("Atualiza aluno - " + nome);
    submitModal.text("Atualizar");

    $("#nome").val(nome);
    $("#sobrenome").val(sobrenome);
    $("#telefone").val(telefone);
    $("#ra").val(ra);
}

function del(Id, nome) {
    idModalDel.val(Id);
    modalBodyDel.text("Tem certeza que você quem excluir " + nome + "?");
}

cancelarModal.click(() => {
    limparCampos();
});

function limparCampos() {
    $("#nome").val("");
    $("#sobrenome").val("");
    $("#telefone").val("");
    $("#ra").val("");
    tipoModal.val("");
    idModal.val("");
    idModalDel.val("");
    modalBodyDel.text("");
}