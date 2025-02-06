/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Updates the throughput mode or the amount of provisioned throughput of an existing
    /// file system.
    /// </summary>
    [Cmdlet("Update", "EFSFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System UpdateFileSystem API operation.", Operation = new[] {"UpdateFileSystem"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse object containing multiple properties."
    )]
    public partial class UpdateEFSFileSystemCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system that you want to update.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughputInMibp
        /// <summary>
        /// <para>
        /// <para>(Optional) The throughput, measured in mebibytes per second (MiBps), that you want
        /// to provision for a file system that you're creating. Required if <c>ThroughputMode</c>
        /// is set to <c>provisioned</c>. Valid values are 1-3414 MiBps, with the upper limit
        /// depending on Region. To increase this limit, contact Amazon Web Services Support.
        /// For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/limits.html#soft-limits">Amazon
        /// EFS quotas that you can increase</a> in the <i>Amazon EFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedThroughputInMibps")]
        public System.Double? ProvisionedThroughputInMibp { get; set; }
        #endregion
        
        #region Parameter ThroughputMode
        /// <summary>
        /// <para>
        /// <para>(Optional) Updates the file system's throughput mode. If you're not updating your
        /// throughput mode, you don't need to provide this value in your request. If you are
        /// changing the <c>ThroughputMode</c> to <c>provisioned</c>, you must also set a value
        /// for <c>ProvisionedThroughputInMibps</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.ThroughputMode")]
        public Amazon.ElasticFileSystem.ThroughputMode ThroughputMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EFSFileSystem (UpdateFileSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse, UpdateEFSFileSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedThroughputInMibp = this.ProvisionedThroughputInMibp;
            context.ThroughputMode = this.ThroughputMode;
            
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
            var request = new Amazon.ElasticFileSystem.Model.UpdateFileSystemRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.ProvisionedThroughputInMibp != null)
            {
                request.ProvisionedThroughputInMibps = cmdletContext.ProvisionedThroughputInMibp.Value;
            }
            if (cmdletContext.ThroughputMode != null)
            {
                request.ThroughputMode = cmdletContext.ThroughputMode;
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
        
        private Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.UpdateFileSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "UpdateFileSystem");
            try
            {
                #if DESKTOP
                return client.UpdateFileSystem(request);
                #elif CORECLR
                return client.UpdateFileSystemAsync(request).GetAwaiter().GetResult();
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
            public System.String FileSystemId { get; set; }
            public System.Double? ProvisionedThroughputInMibp { get; set; }
            public Amazon.ElasticFileSystem.ThroughputMode ThroughputMode { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.UpdateFileSystemResponse, UpdateEFSFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
