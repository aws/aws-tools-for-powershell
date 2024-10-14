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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Retrieves an analysis template within a collaboration.
    /// </summary>
    [Cmdlet("Get", "CRSCollaborationAnalysisTemplate")]
    [OutputType("Amazon.CleanRooms.Model.CollaborationAnalysisTemplate")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service GetCollaborationAnalysisTemplate API operation.", Operation = new[] {"GetCollaborationAnalysisTemplate"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.CollaborationAnalysisTemplate or Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.CollaborationAnalysisTemplate object.",
        "The service call response (type Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCRSCollaborationAnalysisTemplateCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the analysis template within a collaboration.</para>
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
        public System.String AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter CollaborationIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the collaboration that the analysis templates belong to. Currently
        /// accepts collaboration ID.</para>
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
        public System.String CollaborationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CollaborationAnalysisTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CollaborationAnalysisTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnalysisTemplateArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnalysisTemplateArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnalysisTemplateArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse, GetCRSCollaborationAnalysisTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnalysisTemplateArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalysisTemplateArn = this.AnalysisTemplateArn;
            #if MODULAR
            if (this.AnalysisTemplateArn == null && ParameterWasBound(nameof(this.AnalysisTemplateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisTemplateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CollaborationIdentifier = this.CollaborationIdentifier;
            #if MODULAR
            if (this.CollaborationIdentifier == null && ParameterWasBound(nameof(this.CollaborationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaborationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateRequest();
            
            if (cmdletContext.AnalysisTemplateArn != null)
            {
                request.AnalysisTemplateArn = cmdletContext.AnalysisTemplateArn;
            }
            if (cmdletContext.CollaborationIdentifier != null)
            {
                request.CollaborationIdentifier = cmdletContext.CollaborationIdentifier;
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
        
        private Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "GetCollaborationAnalysisTemplate");
            try
            {
                #if DESKTOP
                return client.GetCollaborationAnalysisTemplate(request);
                #elif CORECLR
                return client.GetCollaborationAnalysisTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String AnalysisTemplateArn { get; set; }
            public System.String CollaborationIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.GetCollaborationAnalysisTemplateResponse, GetCRSCollaborationAnalysisTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CollaborationAnalysisTemplate;
        }
        
    }
}
