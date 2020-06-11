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
    /// Creates an endpoint for a self-managed object storage bucket.
    /// </summary>
    [Cmdlet("New", "DSYNLocationObjectStorage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationObjectStorage API operation.", Operation = new[] {"CreateLocationObjectStorage"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationObjectStorageResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationObjectStorageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationObjectStorageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationObjectStorageCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter BucketAccessKey
        /// <summary>
        /// <para>
        /// <para>Optional. The access key is used if credentials are required to access the self-managed
        /// object storage server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketAccessKey { get; set; }
        #endregion
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the agents associated with the self-managed object
        /// storage server location.</para>
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
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket on the self-managed object storage server that is used to read data from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter BucketSecretKey
        /// <summary>
        /// <para>
        /// <para>Optional. The secret key is used if credentials are required to access the self-managed
        /// object storage server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketSecretKey { get; set; }
        #endregion
        
        #region Parameter ServerHostname
        /// <summary>
        /// <para>
        /// <para>The name of the self-managed object storage server. This value is the IP address or
        /// Domain Name Service (DNS) name of the object storage server. An agent uses this host
        /// name to mount the object storage server in a network. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServerHostname { get; set; }
        #endregion
        
        #region Parameter ServerPort
        /// <summary>
        /// <para>
        /// <para>The port that your self-managed object storage server accepts inbound network traffic
        /// on. The server port is set by default to TCP 80 (HTTP) or TCP 443 (HTTPS). You can
        /// specify a custom port if your self-managed object storage server requires one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ServerPort { get; set; }
        #endregion
        
        #region Parameter ServerProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol that the object storage server uses to communicate. Valid values are
        /// HTTP or HTTPS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.ObjectStorageServerProtocol")]
        public Amazon.DataSync.ObjectStorageServerProtocol ServerProtocol { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>The subdirectory in the self-managed object storage server that is used to read data
        /// from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the location. The
        /// value can be an empty string. We recommend using tags to name your resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationObjectStorageResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationObjectStorageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationObjectStorage (CreateLocationObjectStorage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationObjectStorageResponse, NewDSYNLocationObjectStorageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketAccessKey = this.BucketAccessKey;
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
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BucketSecretKey = this.BucketSecretKey;
            context.ServerHostname = this.ServerHostname;
            #if MODULAR
            if (this.ServerHostname == null && ParameterWasBound(nameof(this.ServerHostname)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerHostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerPort = this.ServerPort;
            context.ServerProtocol = this.ServerProtocol;
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataSync.Model.CreateLocationObjectStorageRequest();
            
            if (cmdletContext.BucketAccessKey != null)
            {
                request.AccessKey = cmdletContext.BucketAccessKey;
            }
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.BucketSecretKey != null)
            {
                request.SecretKey = cmdletContext.BucketSecretKey;
            }
            if (cmdletContext.ServerHostname != null)
            {
                request.ServerHostname = cmdletContext.ServerHostname;
            }
            if (cmdletContext.ServerPort != null)
            {
                request.ServerPort = cmdletContext.ServerPort.Value;
            }
            if (cmdletContext.ServerProtocol != null)
            {
                request.ServerProtocol = cmdletContext.ServerProtocol;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DataSync.Model.CreateLocationObjectStorageResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationObjectStorageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationObjectStorage");
            try
            {
                #if DESKTOP
                return client.CreateLocationObjectStorage(request);
                #elif CORECLR
                return client.CreateLocationObjectStorageAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketAccessKey { get; set; }
            public List<System.String> AgentArn { get; set; }
            public System.String BucketName { get; set; }
            public System.String BucketSecretKey { get; set; }
            public System.String ServerHostname { get; set; }
            public System.Int32? ServerPort { get; set; }
            public Amazon.DataSync.ObjectStorageServerProtocol ServerProtocol { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationObjectStorageResponse, NewDSYNLocationObjectStorageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
