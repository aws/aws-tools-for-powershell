/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    public partial class NewEC2InstanceCmdlet
    {
        #region Parameter AssociatePublicIp
        /// <summary>
        /// Indicates whether to assign a public IP address to an instance in a VPC.      
        /// </summary>
        /// <remarks>
        /// <para>The public IP address is associated with a specific network interface. 
        /// If set to true, the following rules apply:</para>
        /// <ol>
        /// <li>
        /// <p>Can only be associated with a single network interface with
        /// the device index of 0. You can't associate a public IP address
        /// with a second network interface, and you can't associate a
        /// public IP address if you are launching more than one network
        /// interface.</p>
        /// </li>
        /// <li>
        /// <p>Can only be associated with a new network interface, 
        /// not an existing one.</p>
        /// </li>
        /// </ol>
        /// <p>
        /// Default: If launching into a default subnet, the default value is <b>true</b>.
        /// If launching into a nondefault subnet, the default value is <b>false</b>. 
        /// </p>
        /// </remarks>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociatePublicIp { get; set; }
        #endregion

        #region Parameter UserDataFile
        /// <summary>
        /// The name of a file containing base64-encoded MIME user data for the instances. 
        /// Using this parameter causes any value for the UserData parameter to be ignored. 
        /// If the -EncodeUserData switch is also set, the contents of the file can be normal 
        /// ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDataFile { get; set; }
        #endregion

        #region Parameter EncodeUserData
        /// <summary>
        /// If set and the -UserData or -UserDataFile parameters are specified, the specified
        /// user data is base64 encoded prior to submitting to EC2. By default the user data
        /// is assumed to be encoded prior to being supplied to the cmdlet.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter EncodeUserData { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (this.AssociatePublicIp.HasValue)
            {
                if (cmdletContext.NetworkInterface == null)
                {
                    // Else initialize the NetworkInterfaceSet property,
                    // create an InstanceNetworkInterfaceSpecification with DeviceIndex 0 and
                    // set the flag.
                    var netInterface = new InstanceNetworkInterfaceSpecification
                    {
                        DeviceIndex = 0,
                        AssociatePublicIpAddress = this.AssociatePublicIp.Value,
                        SubnetId = cmdletContext.SubnetId,
                        PrivateIpAddress = cmdletContext.PrivateIpAddress,
                    };

                    if (cmdletContext.SecurityGroupId != null)
                        netInterface.Groups = cmdletContext.SecurityGroupId;

                    cmdletContext.NetworkInterface = new List<InstanceNetworkInterfaceSpecification>
                    {
                        netInterface
                    };

                    // Set SubnetId and PrivateIpAddress to null as we have processed these parameters
                    // at NIC level.
                    cmdletContext.SubnetId = null;
                    cmdletContext.PrivateIpAddress = null;
                    cmdletContext.SecurityGroupId = null;
                }
                else
                {
                    // Set the flag on the Network Interface with Deviceindex 0 if Network Interfaces are specified.
                    var networkInterface0 = cmdletContext.NetworkInterface.SingleOrDefault(
                        n => n.DeviceIndex == 0);
                    if (networkInterface0 != null)
                    {
                        networkInterface0.AssociatePublicIpAddress = this.AssociatePublicIp.Value;
                    }
                }
            }

            try
            {
                cmdletContext.UserData = AmazonEC2Helper.LoadUserData(this.UserData, this.UserDataFile, this.EncodeUserData);
            }
            catch (IOException e)
            {
                ThrowArgumentError("Error attempting to access UserDataFile.", UserDataFile, e);
            }
        }        
    }
}
