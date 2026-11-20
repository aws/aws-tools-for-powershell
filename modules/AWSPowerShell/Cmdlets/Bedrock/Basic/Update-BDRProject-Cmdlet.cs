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
using System.Threading;
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates one mutable project field per call: exactly one of <c>name</c> or <c>dataRetention</c>
    /// must be set. The default project and archived projects cannot be updated.
    /// </summary>
    [Cmdlet("Update", "BDRProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.UpdateProjectResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateProject API operation.", Operation = new[] {"UpdateProject"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateProjectResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.UpdateProjectResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.UpdateProjectResponse object containing multiple properties."
    )]
    public partial class UpdateBDRProjectCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataRetention_Mode
        /// <summary>
        /// <para>
        /// <para>The project's data retention mode. Use <c>inherit</c> to defer to the account setting
        /// or model default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.DataRetentionMode")]
        public Amazon.Bedrock.DataRetentionMode DataRetention_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The project's new display name. Specify this field only when <c>dataRetention</c>
        /// is omitted. Project names do not have to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The id or ARN of the project to update.</para>
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
        public System.String ProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateProjectResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateProjectResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRProject (UpdateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateProjectResponse, UpdateBDRProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataRetention_Mode = this.DataRetention_Mode;
            context.Name = this.Name;
            context.ProjectIdentifier = this.ProjectIdentifier;
            #if MODULAR
            if (this.ProjectIdentifier == null && ParameterWasBound(nameof(this.ProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.UpdateProjectRequest();
            
            
             // populate DataRetention
            var requestDataRetentionIsNull = true;
            request.DataRetention = new Amazon.Bedrock.Model.ProjectDataRetention();
            Amazon.Bedrock.DataRetentionMode requestDataRetention_dataRetention_Mode = null;
            if (cmdletContext.DataRetention_Mode != null)
            {
                requestDataRetention_dataRetention_Mode = cmdletContext.DataRetention_Mode;
            }
            if (requestDataRetention_dataRetention_Mode != null)
            {
                request.DataRetention.Mode = requestDataRetention_dataRetention_Mode;
                requestDataRetentionIsNull = false;
            }
             // determine if request.DataRetention should be set to null
            if (requestDataRetentionIsNull)
            {
                request.DataRetention = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectIdentifier != null)
            {
                request.ProjectIdentifier = cmdletContext.ProjectIdentifier;
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
        
        private Amazon.Bedrock.Model.UpdateProjectResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateProject");
            try
            {
                return client.UpdateProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.DataRetentionMode DataRetention_Mode { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateProjectResponse, UpdateBDRProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
