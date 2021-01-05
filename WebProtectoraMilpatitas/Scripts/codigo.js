
function cargarFoto(inp) {
	let filereader = new FileReader();
	filereader.onload = function () {

		inp.parentNode.querySelector('img').src = filereader.result;
	};

	filereader.readAsDataURL(inp.files[0]);
	console.log(filereader);
}


function mensajeModal() {
    let div = document.createElement('div');
    let html = '<article id=ar><h2>Contrato</h2><p>Has creado el contrato, haz click aqui para descargar</p ><p>@Html.ActionLink("Contrato", "Imprimir", "ContratoAdopcion")</p> <footer><button class=button onclick=cerrarMensajeModal();>cerrar</button></footer ></article > ';
    div.setAttribute('id', 'capafondo');
    div.innerHTML = html;

    document.querySelector('body').appendChild(div);
}

function cerrarMensajeModal() {
    document.querySelector('#capafondo').remove();
}