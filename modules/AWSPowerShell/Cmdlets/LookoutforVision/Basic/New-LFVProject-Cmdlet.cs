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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Creates an empty Amazon Lookout for Vision project. After you create the project,
    /// add a dataset by calling <a>CreateDataset</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <c>lookoutvision:CreateProject</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LFVProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.Model.ProjectMetadata")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.Model.ProjectMetadata or Amazon.LookoutforVision.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.LookoutforVision.Model.ProjectMetadata object.",
        "The service call response (type Amazon.LookoutforVision.Model.CreateProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLFVProjectCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name for the project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <c>CreateProject</c> completes
        /// only once. You choose the value to pass. For example, An issue might prevent you from
        /// getting a response from <c>CreateProject</c>. In this case, safely retry your call
        /// to <c>CreateProject</c> by using the same <c>ClientToken</c> parameter value. </para><para>If you don't supply a value for <c>ClientToken</c>, the AWS SDK you are using inserts
        /// a value for you. This prevents retries after a network error from making multiple
        /// project creation requests. You'll need to provide your own value for other use cases.
        /// </para><para>An error occurs if the other input parameters are not the same as in the first request.
        /// Using a different value for <c>ClientToken</c> is considered a new call to <c>CreateProject</c>.
        /// An idempotency token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProjectMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.CreateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProjectMetadata";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LFVProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.CreateProjectResponse, NewLFVProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.CreateProjectRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "CreateProject");
            try
            {
                #if DESKTOP
                return client.CreateProject(request);
                #elif CORECLR
                return client.CreateProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.CreateProjectResponse, NewLFVProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProjectMetadata;
        }
        
    }
}
