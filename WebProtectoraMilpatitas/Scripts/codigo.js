
function cargarFoto(inp) {
	let filereader = new FileReader();
	filereader.onload = function () {

		inp.parentNode.querySelector('img').src = filereader.result;
	};

	filereader.readAsDataURL(inp.files[0]);
	console.log(filereader);
}