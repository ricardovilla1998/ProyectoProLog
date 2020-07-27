:-dynamic respuesta/1.
:-dynamic pregunta/2.
:-dynamic carrera/1.
:-dynamic consultar/3.
:-dynamic verificar/2.

%RESPONDER
respuesta(si).
respuesta(no).


%Sistemas
pregunta('�Te gusta resolver problemas con la computadora?',sistemas).
pregunta('�Sabes usar bien una computadora?',sistemas).
pregunta('�Te gustaria crear un videojuego?',sistemas).
pregunta('�Consideras que tienes un buen razonamiento l�gico?',sistemas).
pregunta('�Te gusta el desarrollo de nuevas tecnolog�as?',sistemas).

%Administracion
pregunta('�Tienes la capacidad de ser lider?',administracion).
pregunta('�Te gusta saber sobre temas econ�micos?',administracion).
pregunta('�Eres h�bil con temas de estad�stica?',administracion).
pregunta('�Consideras que tienes habilidad para negociar?',administracion).
pregunta('�Consideras que tienes habilidad para la contabilidad?',administracion).

%Gastronomia
pregunta('�Te gusta cocinar?',gastronomia).
pregunta('�Te interesa aprender sobre otras culturas?',gastronomia).
pregunta('�Te interesa aprender nuevos idiomas?',gastronomia).
pregunta('�Te consideras una persona creativa?',gastronomia).
pregunta('�Consideras la cocina como un arte?',gastronomia).


%Civil
pregunta('�Te gusta la construccion?',civil).
pregunta('�Te gusta observar las obras de ingenieria de tu ciudad?',civil).
pregunta('�Te gusta el dibujo tecnico?',civil).
pregunta('�Te la pasas informado de las construcciones que suceden a tu alrededor?',civil).
pregunta('�Te gusta el calculo?',civil).


%Medicina
pregunta('�Te gusta ayudar a las personas?',medicina).
pregunta('�Te fascina la anatomia del cuerpo humano?',medicina).
pregunta('�Soportas ver heridas?',medicina).
pregunta('�Te gusta curar a tus amigos o familiares?',medicina).
pregunta('�Estas al tanto de los nuevos tratamientos o medicamentos que salen con a�o?',medicina).

%Arqueologia
pregunta('�Te gustan las excavaciones?',arqueologia).
pregunta('�Te gusta la Historia?',arqueologia).
pregunta('�Te emocionas cuando te enteras de descubrimientos arqueologicos?',arqueologia).
pregunta('�Te gustan los museos?',arqueologia).
pregunta('�Te gusta visitar ruinas antiguas?',arqueologia).


cargar(A):-exists_file(A),consult(A).

%VERIFICAR RESPUESTAS

consultar(X,Y,Z):- pregunta(X,Y),respuesta(Z),verificar(Y,Z).
verificar(Y,Z):- (

    Y = sistemas , Z = si -> true;
    X = administracion , Y = si -> true;
    X = gastronomia , Y = si -> true;
    X = civil , Y = si -> true;
    X = medicina , Y = si -> true;
    X = arqueologia , Y = si -> true

).
