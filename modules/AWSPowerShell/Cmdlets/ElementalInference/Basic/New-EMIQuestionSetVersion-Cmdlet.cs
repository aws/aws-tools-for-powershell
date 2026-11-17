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
using Amazon.ElementalInference;
using Amazon.ElementalInference.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMI
{
    /// <summary>
    /// Publishes the DRAFT version of the specified question set as a new version. The new
    /// version has the same name and questions as DRAFT, and you can't change it. DRAFT doesn't
    /// change, so you can continue to update it. 
    /// 
    ///  
    /// <para>
    /// Version numbers start at 1, and each new version has the next number. Elemental Inference
    /// never reuses a version number, even after you delete that version. 
    /// </para><para>
    /// If DRAFT hasn't changed since the latest published version, Elemental Inference doesn't
    /// create a version. Instead, it returns the latest version. A change to the name of
    /// the question set counts as a change to DRAFT. 
    /// </para><para>
    /// A question set can have a limited number of versions. If the question set already
    /// has the maximum number of versions, Elemental Inference returns ServiceQuotaExceededException.
    /// To free space for a new version, delete a version that you no longer need, or create
    /// a new question set. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EMIQuestionSetVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference CreateQuestionSetVersion API operation.", Operation = new[] {"CreateQuestionSetVersion"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse object containing multiple properties."
    )]
    public partial class NewEMIQuestionSetVersionCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the new version. You can't change the description after Elemental
        /// Inference publishes the version. If DRAFT hasn't changed since the latest version,
        /// Elemental Inference ignores this value and returns the latest version with its existing
        /// description. </para><para>The description can be up to 256 characters. It can contain the letters A-Z and a-z,
        /// the digits 0-9, underscores, spaces, and the following characters: <c>- . ' , @ :
        /// ;</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the question set whose DRAFT version you want to publish.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Sha256
        /// <summary>
        /// <para>
        /// <para>The SHA-256 hash of the DRAFT version that you want to publish, as returned by GetQuestionSet
        /// or UpdateQuestionSet. If you specify this value, Elemental Inference publishes DRAFT
        /// only if its current hash matches. If it doesn't match, because DRAFT changed after
        /// you retrieved it, the request fails with ConflictException. </para><para>If you don't specify this value, Elemental Inference publishes DRAFT as it is when
        /// it receives the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sha256 { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMIQuestionSetVersion (CreateQuestionSetVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse, NewEMIQuestionSetVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sha256 = this.Sha256;
            
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
            var request = new Amazon.ElementalInference.Model.CreateQuestionSetVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Sha256 != null)
            {
                request.Sha256 = cmdletContext.Sha256;
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
        
        private Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.CreateQuestionSetVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "CreateQuestionSetVersion");
            try
            {
                return client.CreateQuestionSetVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String Sha256 { get; set; }
            public System.Func<Amazon.ElementalInference.Model.CreateQuestionSetVersionResponse, NewEMIQuestionSetVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
