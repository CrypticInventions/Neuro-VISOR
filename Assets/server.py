
#   Binds REP socket to tcp://*:5555


import zmq
import os
context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

while True:
    #  Wait for next request from client
    message = socket.recv()
    print("Received request: %s" % message)
    os.system('wsl -e sh -c "cd /mnt/c/Users/DefaultUser/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes; python3 New_Generate_meshes.py -i cells/0-2a.CNG.swc')
    try:
        os.rename("C:/Users/DefaultUser/Documents/GitHub/Neuro-VISOR/Assets/PythonNeuronMeshes/0-2a.CNG.mesh.vrn", "C:/Users/DefaultUser/Documents/GitHub/Neuro-VISOR/Assets/StreamingAssets/NeuronalDynamics/Geometries/0-2a.CNG.mesh.vrn")
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
