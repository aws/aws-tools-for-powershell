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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Creates a replication conﬁguration to either a new or existing EFS file system. For
    /// more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-replication.html">Amazon
    /// EFS replication</a> in the <i>Amazon EFS User Guide</i>. The replication configuration
    /// specifies the following:
    /// 
    ///  <ul><li><para><b>Source file system</b> – The EFS file system that you want to replicate. 
    /// </para></li><li><para><b>Destination file system</b> – The destination file system to which the source
    /// file system is replicated. There can only be one destination file system in a replication
    /// configuration. 
    /// </para><note><para>
    /// A file system can be part of only one replication configuration. 
    /// </para></note><para>
    /// The destination parameters for the replication configuration depend on whether you
    /// are replicating to a new file system or to an existing file system, and if you are
    /// replicating across Amazon Web Services accounts. See <a>DestinationToCreate</a> for
    /// more information.
    /// </para></li></ul><para>
    /// This operation requires permissions for the <c>elasticfilesystem:CreateReplicationConfiguration</c>
    /// action. Additionally, other permissions are required depending on how you are replicating
    /// file systems. For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-replication.html#efs-replication-permissions">Required
    /// permissions for replication</a> in the <i>Amazon EFS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSReplicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System CreateReplicationConfiguration API operation.", Operation = new[] {"CreateReplicationConfiguration"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse object containing multiple properties."
    )]
    public partial class NewEFSReplicationConfigurationCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>An array of destination configuration objects. Only one destination configuration
        /// object is supported.</para>
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
        [Alias("Destinations")]
        public Amazon.ElasticFileSystem.Model.DestinationToCreate[] Destination { get; set; }
        #endregion
        
        #region Parameter SourceFileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon EFS file system that you want to replicate. This file system
        /// cannot already be a source or destination file system in another replication configuration.</para>
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
        public System.String SourceFileSystemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceFileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSReplicationConfiguration (CreateReplicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse, NewEFSReplicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.ElasticFileSystem.Model.DestinationToCreate>(this.Destination);
            }
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceFileSystemId = this.SourceFileSystemId;
            #if MODULAR
            if (this.SourceFileSystemId == null && ParameterWasBound(nameof(this.SourceFileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceFileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.SourceFileSystemId != null)
            {
                request.SourceFileSystemId = cmdletContext.SourceFileSystemId;
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
        
        private Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "CreateReplicationConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateReplicationConfiguration(request);
                #elif CORECLR
                return client.CreateReplicationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticFileSystem.Model.DestinationToCreate> Destination { get; set; }
            public System.String SourceFileSystemId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse, NewEFSReplicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
