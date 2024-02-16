
#   Binds REP socket to tcp://*:5555


import zmq
import os
import shutil
context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

while True:
    #  Wait for next request from client
    message = socket.recv()
    print("Received request: %s" % message)
    os.system('wsl -e sh -c "cd /mnt/c/Users/bhugg/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes; python3 New_Generate_meshes.py -i cells/09-06-01-4neurogliaform.CNG.swc')
    try:
        #was previously "/Users/DefaultUser/bhugg/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/*.vrn"
        shutil.move("/Users/DefaultUser/bhugg/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/09-06-01-4neurogliaform.CNG.vrn", "/Users/DefaultUser/bhugg/GitHub/Neuro-VISOR/Assets/StreamingAssets/NeuronalDynamics/Geometries")
    except:
        socket.send(b"Error requested file is within project already")
    else:
        socket.send(b"Received")


    #  Do some 'work'.
    #  Try reducing sleep time to 0.01 to see how blazingly fast it communicates
    #  In the real world usage, you just need to replace time.sleep() with
    #  whatever work you want python to do, maybe a machine learning task
    #  Send reply back to client
    #  In the real world usage, after you finish your work, send your output here
    print("Received")
