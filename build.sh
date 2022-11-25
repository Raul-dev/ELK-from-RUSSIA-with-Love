# !/bin/bash
#chmod +x build.sh
#docker login docker.io
# ./build.sh "filebeat-alpine" "latest" "8.0.0" "raulamailru"
echo "Container name:$1"
echo "Container local tag:$2"
echo "Container repository tag:$3"
echo "Repository:$4"

#echo "Container expose port:$4"
#--build-arg SERVICE_PORT=$SERVICE_PORT
SERVICE_PORT=$4
CNTNAME="$1:$2"
echo $CNTNAME

BUILDCMD="docker build -f prod.dockerfile -t $CNTNAME --progress plain ."
echo $BUILDCMD
eval $BUILDCMD

BUILDCMD="docker tag $CNTNAME $4/$1:$3"
echo $BUILDCMD
eval $BUILDCMD

BUILDCMD="docker push $4/$1:$3"
echo $BUILDCMD
eval $BUILDCMD

