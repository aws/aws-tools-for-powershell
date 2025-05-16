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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates a persistent application user interface.
    /// </summary>
    [Cmdlet("New", "EMRPersistentAppUI", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce CreatePersistentAppUI API operation.", Operation = new[] {"CreatePersistentAppUI"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse object containing multiple properties."
    )]
    public partial class NewEMRPersistentAppUICmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EMRContainersConfig_JobRunId
        /// <summary>
        /// <para>
        /// <para>The Job run ID for the container configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EMRContainersConfig_JobRunId { get; set; }
        #endregion
        
        #region Parameter ProfilerType
        /// <summary>
        /// <para>
        /// <para>The profiler type for the persistent application user interface. Valid values are
        /// SHS, TEZUI, or YTS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.ProfilerType")]
        public Amazon.ElasticMapReduce.ProfilerType ProfilerType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the persistent application user interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetResourceArn
        /// <summary>
        /// <para>
        /// <para>The unique Amazon Resource Name (ARN) of the target resource.</para>
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
        public System.String TargetResourceArn { get; set; }
        #endregion
        
        #region Parameter XReferer
        /// <summary>
        /// <para>
        /// <para>The cross reference for the persistent application user interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XReferer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRPersistentAppUI (CreatePersistentAppUI)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse, NewEMRPersistentAppUICmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EMRContainersConfig_JobRunId = this.EMRContainersConfig_JobRunId;
            context.ProfilerType = this.ProfilerType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticMapReduce.Model.Tag>(this.Tag);
            }
            context.TargetResourceArn = this.TargetResourceArn;
            #if MODULAR
            if (this.TargetResourceArn == null && ParameterWasBound(nameof(this.TargetResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.XReferer = this.XReferer;
            
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
            var request = new Amazon.ElasticMapReduce.Model.CreatePersistentAppUIRequest();
            
            
             // populate EMRContainersConfig
            var requestEMRContainersConfigIsNull = true;
            request.EMRContainersConfig = new Amazon.ElasticMapReduce.Model.EMRContainersConfig();
            System.String requestEMRContainersConfig_eMRContainersConfig_JobRunId = null;
            if (cmdletContext.EMRContainersConfig_JobRunId != null)
            {
                requestEMRContainersConfig_eMRContainersConfig_JobRunId = cmdletContext.EMRContainersConfig_JobRunId;
            }
            if (requestEMRContainersConfig_eMRContainersConfig_JobRunId != null)
            {
                request.EMRContainersConfig.JobRunId = requestEMRContainersConfig_eMRContainersConfig_JobRunId;
                requestEMRContainersConfigIsNull = false;
            }
             // determine if request.EMRContainersConfig should be set to null
            if (requestEMRContainersConfigIsNull)
            {
                request.EMRContainersConfig = null;
            }
            if (cmdletContext.ProfilerType != null)
            {
                request.ProfilerType = cmdletContext.ProfilerType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetResourceArn != null)
            {
                request.TargetResourceArn = cmdletContext.TargetResourceArn;
            }
            if (cmdletContext.XReferer != null)
            {
                request.XReferer = cmdletContext.XReferer;
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
        
        private Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.CreatePersistentAppUIRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "CreatePersistentAppUI");
            try
            {
                #if DESKTOP
                return client.CreatePersistentAppUI(request);
                #elif CORECLR
                return client.CreatePersistentAppUIAsync(request).GetAwaiter().GetResult();
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
            public System.String EMRContainersConfig_JobRunId { get; set; }
            public Amazon.ElasticMapReduce.ProfilerType ProfilerType { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Tag> Tag { get; set; }
            public System.String TargetResourceArn { get; set; }
            public System.String XReferer { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.CreatePersistentAppUIResponse, NewEMRPersistentAppUICmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
