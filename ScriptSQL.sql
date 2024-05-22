PGDMP           	            |            optativo    16.2    16.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                        0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16409    optativo    DATABASE     ~   CREATE DATABASE optativo WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Paraguay.1252';
    DROP DATABASE optativo;
                postgres    false            �            1259    16446    cliente    TABLE     M  CREATE TABLE public.cliente (
    id integer NOT NULL,
    id_banco integer NOT NULL,
    nombre character varying(30),
    apellido character varying(30),
    documento character varying(30),
    direccion character varying(50),
    mail character varying(50),
    celular character varying(20),
    estado character varying(20)
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    16445    cliente_id_banco_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_banco_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.cliente_id_banco_seq;
       public          postgres    false    219                       0    0    cliente_id_banco_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.cliente_id_banco_seq OWNED BY public.cliente.id_banco;
          public          postgres    false    218            �            1259    16444    cliente_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.cliente_id_seq;
       public          postgres    false    219                       0    0    cliente_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.cliente_id_seq OWNED BY public.cliente.id;
          public          postgres    false    217            �            1259    16420    factura    TABLE     �  CREATE TABLE public.factura (
    id_factura integer NOT NULL,
    id_cliente integer,
    nro_factura character varying(50),
    fecha_hora timestamp without time zone,
    total numeric(30,2),
    total_iva5 numeric(30,2),
    total_iva10 numeric(30,2),
    total_iva numeric(30,2),
    total_letras character varying(100),
    sucursal character varying(100),
    id_sucursal integer
);
    DROP TABLE public.factura;
       public         heap    postgres    false            �            1259    16419    factura_id_factura_seq    SEQUENCE     �   CREATE SEQUENCE public.factura_id_factura_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.factura_id_factura_seq;
       public          postgres    false    216                       0    0    factura_id_factura_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.factura_id_factura_seq OWNED BY public.factura.id_factura;
          public          postgres    false    215            �            1259    16535    sucursal    TABLE       CREATE TABLE public.sucursal (
    id integer NOT NULL,
    descripcion character varying(200),
    direccion character varying(200),
    telefono character varying(30),
    whatsapp character varying(30),
    mail character varying(50),
    estado character varying(20)
);
    DROP TABLE public.sucursal;
       public         heap    postgres    false            �            1259    16534    sucursal_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sucursal_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.sucursal_id_seq;
       public          postgres    false    221                       0    0    sucursal_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.sucursal_id_seq OWNED BY public.sucursal.id;
          public          postgres    false    220            \           2604    16449 
   cliente id    DEFAULT     h   ALTER TABLE ONLY public.cliente ALTER COLUMN id SET DEFAULT nextval('public.cliente_id_seq'::regclass);
 9   ALTER TABLE public.cliente ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    217    219            [           2604    16423    factura id_factura    DEFAULT     x   ALTER TABLE ONLY public.factura ALTER COLUMN id_factura SET DEFAULT nextval('public.factura_id_factura_seq'::regclass);
 A   ALTER TABLE public.factura ALTER COLUMN id_factura DROP DEFAULT;
       public          postgres    false    215    216    216            ]           2604    16538    sucursal id    DEFAULT     j   ALTER TABLE ONLY public.sucursal ALTER COLUMN id SET DEFAULT nextval('public.sucursal_id_seq'::regclass);
 :   ALTER TABLE public.sucursal ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    221    220    221            �          0    16446    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    219   T"       �          0    16420    factura 
   TABLE DATA           �   COPY public.factura (id_factura, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal, id_sucursal) FROM stdin;
    public          postgres    false    216   E#       �          0    16535    sucursal 
   TABLE DATA           `   COPY public.sucursal (id, descripcion, direccion, telefono, whatsapp, mail, estado) FROM stdin;
    public          postgres    false    221   �$                  0    0    cliente_id_banco_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.cliente_id_banco_seq', 1, true);
          public          postgres    false    218                       0    0    cliente_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.cliente_id_seq', 5, true);
          public          postgres    false    217                       0    0    factura_id_factura_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.factura_id_factura_seq', 8, true);
          public          postgres    false    215            	           0    0    sucursal_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.sucursal_id_seq', 5, true);
          public          postgres    false    220            a           2606    16454    cliente clienteKEY 
   CONSTRAINT     R   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT "clienteKEY" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT "clienteKEY";
       public            postgres    false    219            _           2606    16425    factura factura_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id_factura);
 >   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_pkey;
       public            postgres    false    216            c           2606    16542    sucursal sucursal_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.sucursal
    ADD CONSTRAINT sucursal_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.sucursal DROP CONSTRAINT sucursal_pkey;
       public            postgres    false    221            d           2606    16479    factura id_cliente    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT id_cliente FOREIGN KEY (id_cliente) REFERENCES public.cliente(id) NOT VALID;
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT id_cliente;
       public          postgres    false    219    216    4705            e           2606    16543    factura id_sucursal    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT id_sucursal FOREIGN KEY (id_sucursal) REFERENCES public.sucursal(id) NOT VALID;
 =   ALTER TABLE ONLY public.factura DROP CONSTRAINT id_sucursal;
       public          postgres    false    216    221    4707            �   �   x�]�Kj�0���>���a[���BKZ�v3("Q��
%��r��:�������p��-�K�^���$�=�O{�ڭ�c WB	�2�3��z52!������=ņ��5�9�s�b!��q�y�9��B�o�d���NR�@d?,��T(�.f����a��mֱ�+�S��آ���.�����
	녔�����T�Fƅ�Z�Qn��[���PE���׮i�Oն`       �   �  x�}��n�0���)�T�ʭ�SwXw�%cHCZa����~ΟRm�v�b��m)b(P@� ��Ȗ`Jp�scPK��
@��$b)F��~�Nm�����O����or=�j7w�7�n�[?x���Ө��*L �\I��4Bc���s���9�T��Se!��;g�S/2Bl�����n��\ 0ʈ[�E&�Cl3���L@�{A.�RlJM��0�Z��A�#��з���_�Y�e$ȶD��z� k��@( r��񕉉隣]��~��q8��WXT!�l��mG�DKh���d��}�zq�/.N�͚L����\��Y��K��Ų���b;{����n�Z��2�8j1�e�1.�����o�XJï�zj�ǻ��g�MqXE���      �   �   x�u�=n�0��>�N X�;���[ۥ�օ�ـ@$��1���N������@*���%v�4�;4��I��=b (�m�t�i���}-�q�!u'�|��[�M�������B�J��,K �K�P��������G�	E?�ؠC������Y�ט��!�Q(�n�n�zbr�;�"�
=U�J$>�Ha������m�\2iS�J�"���w|��dQ��y�     