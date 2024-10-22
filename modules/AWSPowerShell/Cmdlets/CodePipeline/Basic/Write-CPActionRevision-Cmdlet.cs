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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Provides information to CodePipeline about new revisions to a source.
    /// </summary>
    [Cmdlet("Write", "CPActionRevision", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodePipeline.Model.PutActionRevisionResponse")]
    [AWSCmdlet("Calls the AWS CodePipeline PutActionRevision API operation.", Operation = new[] {"PutActionRevision"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PutActionRevisionResponse))]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.PutActionRevisionResponse",
        "This cmdlet returns an Amazon.CodePipeline.Model.PutActionRevisionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPActionRevisionCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>The name of the action that processes the revision.</para>
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
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter ActionRevision_Created
        /// <summary>
        /// <para>
        /// <para>The date and time when the most recent version of the action was created, in timestamp
        /// format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ActionRevision_Created { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline that starts processing the revision to the source.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter ActionRevision_RevisionChangeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the change that set the state to this revision (for example,
        /// a deployment ID or timestamp).</para>
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
        public System.String ActionRevision_RevisionChangeId { get; set; }
        #endregion
        
        #region Parameter ActionRevision_RevisionId
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID that identifies the revision number of the action.</para>
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
        public System.String ActionRevision_RevisionId { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage that contains the action that acts on the revision.</para>
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
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PutActionRevisionResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.PutActionRevisionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPActionRevision (PutActionRevision)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PutActionRevisionResponse, WriteCPActionRevisionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionName = this.ActionName;
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionRevision_Created = this.ActionRevision_Created;
            #if MODULAR
            if (this.ActionRevision_Created == null && ParameterWasBound(nameof(this.ActionRevision_Created)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionRevision_Created which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionRevision_RevisionChangeId = this.ActionRevision_RevisionChangeId;
            #if MODULAR
            if (this.ActionRevision_RevisionChangeId == null && ParameterWasBound(nameof(this.ActionRevision_RevisionChangeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionRevision_RevisionChangeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionRevision_RevisionId = this.ActionRevision_RevisionId;
            #if MODULAR
            if (this.ActionRevision_RevisionId == null && ParameterWasBound(nameof(this.ActionRevision_RevisionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionRevision_RevisionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StageName = this.StageName;
            #if MODULAR
            if (this.StageName == null && ParameterWasBound(nameof(this.StageName)))
            {
                WriteWarning("You are passing $null as a value for parameter StageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodePipeline.Model.PutActionRevisionRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            
             // populate ActionRevision
            var requestActionRevisionIsNull = true;
            request.ActionRevision = new Amazon.CodePipeline.Model.ActionRevision();
            System.DateTime? requestActionRevision_actionRevision_Created = null;
            if (cmdletContext.ActionRevision_Created != null)
            {
                requestActionRevision_actionRevision_Created = cmdletContext.ActionRevision_Created.Value;
            }
            if (requestActionRevision_actionRevision_Created != null)
            {
                request.ActionRevision.Created = requestActionRevision_actionRevision_Created.Value;
                requestActionRevisionIsNull = false;
            }
            System.String requestActionRevision_actionRevision_RevisionChangeId = null;
            if (cmdletContext.ActionRevision_RevisionChangeId != null)
            {
                requestActionRevision_actionRevision_RevisionChangeId = cmdletContext.ActionRevision_RevisionChangeId;
            }
            if (requestActionRevision_actionRevision_RevisionChangeId != null)
            {
                request.ActionRevision.RevisionChangeId = requestActionRevision_actionRevision_RevisionChangeId;
                requestActionRevisionIsNull = false;
            }
            System.String requestActionRevision_actionRevision_RevisionId = null;
            if (cmdletContext.ActionRevision_RevisionId != null)
            {
                requestActionRevision_actionRevision_RevisionId = cmdletContext.ActionRevision_RevisionId;
            }
            if (requestActionRevision_actionRevision_RevisionId != null)
            {
                request.ActionRevision.RevisionId = requestActionRevision_actionRevision_RevisionId;
                requestActionRevisionIsNull = false;
            }
             // determine if request.ActionRevision should be set to null
            if (requestActionRevisionIsNull)
            {
                request.ActionRevision = null;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
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
        
        private Amazon.CodePipeline.Model.PutActionRevisionResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutActionRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutActionRevision");
            try
            {
                #if DESKTOP
                return client.PutActionRevision(request);
                #elif CORECLR
                return client.PutActionRevisionAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionName { get; set; }
            public System.DateTime? ActionRevision_Created { get; set; }
            public System.String ActionRevision_RevisionChangeId { get; set; }
            public System.String ActionRevision_RevisionId { get; set; }
            public System.String PipelineName { get; set; }
            public System.String StageName { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PutActionRevisionResponse, WriteCPActionRevisionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
