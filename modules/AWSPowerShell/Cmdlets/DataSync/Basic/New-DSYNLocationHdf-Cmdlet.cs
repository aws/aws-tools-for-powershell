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
    /// Creates an endpoint for a Hadoop Distributed File System (HDFS).
    /// </summary>
    [Cmdlet("New", "DSYNLocationHdf", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationHdfs API operation.", Operation = new[] {"CreateLocationHdfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationHdfsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationHdfsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationHdfsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationHdfCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the agents that are used to connect to the HDFS
        /// cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The type of authentication used to determine the identity of the user. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataSync.HdfsAuthenticationType")]
        public Amazon.DataSync.HdfsAuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter BlockSize
        /// <summary>
        /// <para>
        /// <para>The size of data blocks to write into the HDFS cluster. The block size must be a multiple
        /// of 512 bytes. The default block size is 128 mebibytes (MiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BlockSize { get; set; }
        #endregion
        
        #region Parameter QopConfiguration_DataTransferProtection
        /// <summary>
        /// <para>
        /// <para>The data transfer protection setting configured on the HDFS cluster. This setting
        /// corresponds to your <code>dfs.data.transfer.protection</code> setting in the <code>hdfs-site.xml</code>
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
        /// the file's address. If you're using the CLI, it performs base64 encoding for you.
        /// Otherwise, provide the base64-encoded text. </para><note><para>If <code>KERBEROS</code> is specified for <code>AuthenticationType</code>, this parameter
        /// is required. </para></note>
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
        /// <para>The <code>krb5.conf</code> file that contains the Kerberos configuration information.
        /// You can load the <code>krb5.conf</code> file by providing the file's address. If you're
        /// using the CLI, it performs the base64 encoding for you. Otherwise, provide the base64-encoded
        /// text. </para><note><para>If <code>KERBEROS</code> is specified for <code>AuthenticationType</code>, this parameter
        /// is required.</para></note>
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
        /// <para>The Kerberos principal with access to the files and folders on the HDFS cluster. </para><note><para>If <code>KERBEROS</code> is specified for <code>AuthenticationType</code>, this parameter
        /// is required.</para></note>
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
        
        #region Parameter NameNode
        /// <summary>
        /// <para>
        /// <para>The NameNode that manages the HDFS namespace. The NameNode performs operations such
        /// as opening, closing, and renaming files and directories. The NameNode contains the
        /// information to map blocks of data to the DataNodes. You can use only one NameNode.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NameNodes")]
        public Amazon.DataSync.Model.HdfsNameNode[] NameNode { get; set; }
        #endregion
        
        #region Parameter ReplicationFactor
        /// <summary>
        /// <para>
        /// <para>The number of DataNodes to replicate the data to when writing to the HDFS cluster.
        /// By default, data is replicated to three DataNodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReplicationFactor { get; set; }
        #endregion
        
        #region Parameter QopConfiguration_RpcProtection
        /// <summary>
        /// <para>
        /// <para>The RPC protection setting configured on the HDFS cluster. This setting corresponds
        /// to your <code>hadoop.rpc.protection</code> setting in your <code>core-site.xml</code>
        /// file on your Hadoop cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.HdfsRpcProtection")]
        public Amazon.DataSync.HdfsRpcProtection QopConfiguration_RpcProtection { get; set; }
        #endregion
        
        #region Parameter SimpleUser
        /// <summary>
        /// <para>
        /// <para>The user name used to identify the client on the host operating system. </para><note><para>If <code>SIMPLE</code> is specified for <code>AuthenticationType</code>, this parameter
        /// is required. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SimpleUser { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the HDFS cluster. This subdirectory is used to read data from or
        /// write data to the HDFS cluster. If the subdirectory isn't specified, it will default
        /// to <code>/</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the location. The
        /// value can be an empty string. We recommend using tags to name your resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationHdfsResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationHdfsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AuthenticationType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AuthenticationType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AuthenticationType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthenticationType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationHdf (CreateLocationHdfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationHdfsResponse, NewDSYNLocationHdfCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AuthenticationType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            #if MODULAR
            if (this.AgentArn == null && ParameterWasBound(nameof(this.AgentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthenticationType = this.AuthenticationType;
            #if MODULAR
            if (this.AuthenticationType == null && ParameterWasBound(nameof(this.AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlockSize = this.BlockSize;
            context.KerberosKeytab = this.KerberosKeytab;
            context.KerberosKrb5Conf = this.KerberosKrb5Conf;
            context.KerberosPrincipal = this.KerberosPrincipal;
            context.KmsKeyProviderUri = this.KmsKeyProviderUri;
            if (this.NameNode != null)
            {
                context.NameNode = new List<Amazon.DataSync.Model.HdfsNameNode>(this.NameNode);
            }
            #if MODULAR
            if (this.NameNode == null && ParameterWasBound(nameof(this.NameNode)))
            {
                WriteWarning("You are passing $null as a value for parameter NameNode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QopConfiguration_DataTransferProtection = this.QopConfiguration_DataTransferProtection;
            context.QopConfiguration_RpcProtection = this.QopConfiguration_RpcProtection;
            context.ReplicationFactor = this.ReplicationFactor;
            context.SimpleUser = this.SimpleUser;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
            }
            
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
                var request = new Amazon.DataSync.Model.CreateLocationHdfsRequest();
                
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
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DataSync.Model.CreateLocationHdfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationHdfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationHdfs");
            try
            {
                #if DESKTOP
                return client.CreateLocationHdfs(request);
                #elif CORECLR
                return client.CreateLocationHdfsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DataSync.Model.HdfsNameNode> NameNode { get; set; }
            public Amazon.DataSync.HdfsDataTransferProtection QopConfiguration_DataTransferProtection { get; set; }
            public Amazon.DataSync.HdfsRpcProtection QopConfiguration_RpcProtection { get; set; }
            public System.Int32? ReplicationFactor { get; set; }
            public System.String SimpleUser { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationHdfsResponse, NewDSYNLocationHdfCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
