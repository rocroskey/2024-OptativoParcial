PGDMP      )                |            optativo    16.2    16.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16409    optativo    DATABASE     ~   CREATE DATABASE optativo WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Paraguay.1252';
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
       public          postgres    false    219            �           0    0    cliente_id_banco_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.cliente_id_banco_seq OWNED BY public.cliente.id_banco;
          public          postgres    false    218            �            1259    16444    cliente_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.cliente_id_seq;
       public          postgres    false    219            �           0    0    cliente_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.cliente_id_seq OWNED BY public.cliente.id;
          public          postgres    false    217            �            1259    16420    factura    TABLE     k  CREATE TABLE public.factura (
    id_factura integer NOT NULL,
    id_cliente integer,
    nro_factura character varying(50),
    fecha_hora timestamp without time zone,
    total numeric(20,2),
    total_iva5 numeric(20,2),
    total_iva10 numeric(20,2),
    total_iva numeric(20,2),
    total_letras character varying(30),
    sucursal character varying(30)
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
       public          postgres    false    216            �           0    0    factura_id_factura_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.factura_id_factura_seq OWNED BY public.factura.id_factura;
          public          postgres    false    215            W           2604    16449 
   cliente id    DEFAULT     h   ALTER TABLE ONLY public.cliente ALTER COLUMN id SET DEFAULT nextval('public.cliente_id_seq'::regclass);
 9   ALTER TABLE public.cliente ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    217    219    219            V           2604    16423    factura id_factura    DEFAULT     x   ALTER TABLE ONLY public.factura ALTER COLUMN id_factura SET DEFAULT nextval('public.factura_id_factura_seq'::regclass);
 A   ALTER TABLE public.factura ALTER COLUMN id_factura DROP DEFAULT;
       public          postgres    false    215    216    216            �          0    16446    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    219   �       �          0    16420    factura 
   TABLE DATA           �   COPY public.factura (id_factura, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) FROM stdin;
    public          postgres    false    216   �       �           0    0    cliente_id_banco_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.cliente_id_banco_seq', 1, true);
          public          postgres    false    218            �           0    0    cliente_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.cliente_id_seq', 3, true);
          public          postgres    false    217            �           0    0    factura_id_factura_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.factura_id_factura_seq', 2, true);
          public          postgres    false    215            [           2606    16454    cliente clienteKEY 
   CONSTRAINT     R   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT "clienteKEY" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT "clienteKEY";
       public            postgres    false    219            Y           2606    16425    factura factura_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id_factura);
 >   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_pkey;
       public            postgres    false    216            \           2606    16479    factura id_cliente    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT id_cliente FOREIGN KEY (id_cliente) REFERENCES public.cliente(id) NOT VALID;
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT id_cliente;
       public          postgres    false    216    4699    219            �   �   x�]�1�@�z8' �eW���B��hk�?�v	��x+����H,�g�f�`����)m�,Ǟ�s=Jϡ6vÔ���m�HT�q�ӷI
Ey�G$Є�/k�ѿ_�D�g���Xq��w����sa��*��������T���ٛ4n��d��������h縓Nlf4i�.��k��H�      �   N   x�3�4�440Ѕba`�id`d�k`�k`�`h`ebjeVz@YS(m0��8g��)�f�p:��%g��q��qqq �W�     