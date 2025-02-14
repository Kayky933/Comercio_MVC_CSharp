﻿function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('cep').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('complemento').value = ("");
    document.getElementById('endereco').value = ("");
    document.getElementById('uf').value = ("");
}
function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('bairro').value = (conteudo.bairro);
        document.getElementById('endereco').value = (conteudo.logradouro);
        document.getElementById('complemento').value = (conteudo.complemento);
        document.getElementById('uf').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}

function pesquisacep() {
    var valor = document.getElementById('cep').value;
    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('bairro').value = "...";
            document.getElementById('endereco').value = "...";
            document.getElementById('complemento').value = "...";
            document.getElementById('uf').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    }
};