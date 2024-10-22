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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Updates some parameters of a previously created location for a Hadoop Distributed
    /// File System cluster.
    /// </summary>
    [Cmdlet("Update", "DSYNLocationHdf", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateLocationHdfs API operation.", Operation = new[] {"UpdateLocationHdfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateLocationHdfsResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateLocationHdfsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateLocationHdfsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDSYNLocationHdfCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the agents that are used to connect to the HDFS cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The type of authentication used to determine the identity of the user. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.HdfsAuthenticationType")]
        public Amazon.DataSync.HdfsAuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter BlockSize
        /// <summary>
        /// <para>
        /// <para>The size of the data blocks to write into the HDFS cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BlockSize { get; set; }
        #endregion
        
        #region Parameter QopConfiguration_DataTransferProtection
        /// <summary>
        /// <para>
        /// <para>The data transfer protection setting configured on the HDFS cluster. This setting
        /// corresponds to your <c>dfs.data.transfer.protection</c> setting in the <c>hdfs-site.xml</c>
        /// file on your Hadoop cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.HdfsDataTransferProtection")]
        public Amazon.DataSync.HdfsDataTransferProtection QopConfiguration_DataTransferProtection { get; set; }
        #endregion
        
        #region Parameter KerberosKeytab
        /// <summary>
        /// <para>
        /// <para>The Kerberos key table (keytab) that contains mappings between the defined Kerberos
        /// principal and the encrypted keys. You can load the keytab from a file by providing
        /// the file's address. If you use the CLI, it performs base64 encoding for you. Otherwise,
        /// provide the base64-encoded text.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] KerberosKeytab { get; set; }
        #endregion
        
        #region Parameter KerberosKrb5Conf
        /// <summary>
        /// <para>
        /// <para>The <c>krb5.conf</c> file that contains the Kerberos configuration information. You
        /// can load the <c>krb5.conf</c> file by providing the file's address. If you're using
        /// the CLI, it performs the base64 encoding for you. Otherwise, provide the base64-encoded
        /// text.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] KerberosKrb5Conf { get; set; }
        #endregion
        
        #region Parameter KerberosPrincipal
        /// <summary>
        /// <para>
        /// <para>The Kerberos principal with access to the files and folders on the HDFS cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosPrincipal { get; set; }
        #endregion
        
        #region Parameter KmsKeyProviderUri
        /// <summary>
        /// <para>
        /// <para>The URI of the HDFS cluster's Key Management Server (KMS). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyProviderUri { get; set; }
        #endregion
        
        #region Parameter LocationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source HDFS cluster location.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LocationArn { get; set; }
        #endregion
        
        #region Parameter NameNode
        /// <summary>
        /// <para>
        /// <para>The NameNode that manages the HDFS namespace. The NameNode performs operations such
        /// as opening, closing, and renaming files and directories. The NameNode contains the
        /// information to map blocks of data to the DataNodes. You can use only one NameNode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NameNodes")]
        public Amazon.DataSync.Model.HdfsNameNode[] NameNode { get; set; }
        #endregion
        
        #region Parameter ReplicationFactor
        /// <summary>
        /// <para>
        /// <para>The number of DataNodes to replicate the data to when writing to the HDFS cluster.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReplicationFactor { get; set; }
        #endregion
        
        #region Parameter QopConfiguration_RpcProtection
        /// <summary>
        /// <para>
        /// <para>The RPC protection setting configured on the HDFS cluster. This setting corresponds
        /// to your <c>hadoop.rpc.protection</c> setting in your <c>core-site.xml</c> file on
        /// your Hadoop cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.HdfsRpcProtection")]
        public Amazon.DataSync.HdfsRpcProtection QopConfiguration_RpcProtection { get; set; }
        #endregion
        
        #region Parameter SimpleUser
        /// <summary>
        /// <para>
        /// <para>The user name used to identify the client on the host operating system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SimpleUser { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the HDFS cluster. This subdirectory is used to read data from or
        /// write data to the HDFS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateLocationHdfsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNLocationHdf (UpdateLocationHdfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateLocationHdfsResponse, UpdateDSYNLocationHdfCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.AuthenticationType = this.AuthenticationType;
            context.BlockSize = this.BlockSize;
            context.KerberosKeytab = this.KerberosKeytab;
            context.KerberosKrb5Conf = this.KerberosKrb5Conf;
            context.KerberosPrincipal = this.KerberosPrincipal;
            context.KmsKeyProviderUri = this.KmsKeyProviderUri;
            context.LocationArn = this.LocationArn;
            #if MODULAR
            if (this.LocationArn == null && ParameterWasBound(nameof(this.LocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NameNode != null)
            {
                context.NameNode = new List<Amazon.DataSync.Model.HdfsNameNode>(this.NameNode);
            }
            context.QopConfiguration_DataTransferProtection = this.QopConfiguration_DataTransferProtection;
            context.QopConfiguration_RpcProtection = this.QopConfiguration_RpcProtection;
            context.ReplicationFactor = this.ReplicationFactor;
            context.SimpleUser = this.SimpleUser;
            context.Subdirectory = this.Subdirectory;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _KerberosKeytabStream = null;
            System.IO.MemoryStream _KerberosKrb5ConfStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.DataSync.Model.UpdateLocationHdfsRequest();
                
                if (cmdletContext.AgentArn != null)
                {
                    request.AgentArns = cmdletContext.AgentArn;
                }
                if (cmdletContext.AuthenticationType != null)
                {
                    request.AuthenticationType = cmdletContext.AuthenticationType;
                }
                if (cmdletContext.BlockSize != null)
                {
                    request.BlockSize = cmdletContext.BlockSize.Value;
                }
                if (cmdletContext.KerberosKeytab != null)
                {
                    _KerberosKeytabStream = new System.IO.MemoryStream(cmdletContext.KerberosKeytab);
                    request.KerberosKeytab = _KerberosKeytabStream;
                }
                if (cmdletContext.KerberosKrb5Conf != null)
                {
                    _KerberosKrb5ConfStream = new System.IO.MemoryStream(cmdletContext.KerberosKrb5Conf);
                    request.KerberosKrb5Conf = _KerberosKrb5ConfStream;
                }
                if (cmdletContext.KerberosPrincipal != null)
                {
                    request.KerberosPrincipal = cmdletContext.KerberosPrincipal;
                }
                if (cmdletContext.KmsKeyProviderUri != null)
                {
                    request.KmsKeyProviderUri = cmdletContext.KmsKeyProviderUri;
                }
                if (cmdletContext.LocationArn != null)
                {
                    request.LocationArn = cmdletContext.LocationArn;
                }
                if (cmdletContext.NameNode != null)
                {
                    request.NameNodes = cmdletContext.NameNode;
                }
                
                 // populate QopConfiguration
                var requestQopConfigurationIsNull = true;
                request.QopConfiguration = new Amazon.DataSync.Model.QopConfiguration();
                Amazon.DataSync.HdfsDataTransferProtection requestQopConfiguration_qopConfiguration_DataTransferProtection = null;
                if (cmdletContext.QopConfiguration_DataTransferProtection != null)
                {
                    requestQopConfiguration_qopConfiguration_DataTransferProtection = cmdletContext.QopConfiguration_DataTransferProtection;
                }
                if (requestQopConfiguration_qopConfiguration_DataTransferProtection != null)
                {
                    request.QopConfiguration.DataTransferProtection = requestQopConfiguration_qopConfiguration_DataTransferProtection;
                    requestQopConfigurationIsNull = false;
                }
                Amazon.DataSync.HdfsRpcProtection requestQopConfiguration_qopConfiguration_RpcProtection = null;
                if (cmdletContext.QopConfiguration_RpcProtection != null)
                {
                    requestQopConfiguration_qopConfiguration_RpcProtection = cmdletContext.QopConfiguration_RpcProtection;
                }
                if (requestQopConfiguration_qopConfiguration_RpcProtection != null)
                {
                    request.QopConfiguration.RpcProtection = requestQopConfiguration_qopConfiguration_RpcProtection;
                    requestQopConfigurationIsNull = false;
                }
                 // determine if request.QopConfiguration should be set to null
                if (requestQopConfigurationIsNull)
                {
                    request.QopConfiguration = null;
                }
                if (cmdletContext.ReplicationFactor != null)
                {
                    request.ReplicationFactor = cmdletContext.ReplicationFactor.Value;
                }
                if (cmdletContext.SimpleUser != null)
                {
                    request.SimpleUser = cmdletContext.SimpleUser;
                }
                if (cmdletContext.Subdirectory != null)
                {
                    request.Subdirectory = cmdletContext.Subdirectory;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    pipelineOutput = cmdletContext.Select(response, this);
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                return output;
            }
            finally
            {
                if( _KerberosKeytabStream != null)
                {
                    _KerberosKeytabStream.Dispose();
                }
                if( _KerberosKrb5ConfStream != null)
                {
                    _KerberosKrb5ConfStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DataSync.Model.UpdateLocationHdfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateLocationHdfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateLocationHdfs");
            try
            {
                #if DESKTOP
                return client.UpdateLocationHdfs(request);
                #elif CORECLR
                return client.UpdateLocationHdfsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> AgentArn { get; set; }
            public Amazon.DataSync.HdfsAuthenticationType AuthenticationType { get; set; }
            public System.Int32? BlockSize { get; set; }
            public byte[] KerberosKeytab { get; set; }
            public byte[] KerberosKrb5Conf { get; set; }
            public System.String KerberosPrincipal { get; set; }
            public System.String KmsKeyProviderUri { get; set; }
            public System.String LocationArn { get; set; }
            public List<Amazon.DataSync.Model.HdfsNameNode> NameNode { get; set; }
            public Amazon.DataSync.HdfsDataTransferProtection QopConfiguration_DataTransferProtection { get; set; }
            public Amazon.DataSync.HdfsRpcProtection QopConfiguration_RpcProtection { get; set; }
            public System.Int32? ReplicationFactor { get; set; }
            public System.String SimpleUser { get; set; }
            public System.String Subdirectory { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateLocationHdfsResponse, UpdateDSYNLocationHdfCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
