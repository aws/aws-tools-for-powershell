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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>DeleteHIT</c> operation is used to delete HIT that is no longer needed. Only
    /// the Requester who created the HIT can delete it. 
    /// 
    ///  
    /// <para>
    ///  You can only dispose of HITs that are in the <c>Reviewable</c> state, with all of
    /// their submitted assignments already either approved or rejected. If you call the DeleteHIT
    /// operation on a HIT that is not in the <c>Reviewable</c> state (for example, that has
    /// not expired, or still has active assignments), or on a HIT that is Reviewable but
    /// without all of its submitted assignments already approved or rejected, the service
    /// will return an error. 
    /// </para><note><ul><li><para>
    ///  HITs are automatically disposed of after 120 days. 
    /// </para></li><li><para>
    ///  After you dispose of a HIT, you can no longer approve the HIT's rejected assignments.
    /// 
    /// </para></li><li><para>
    ///  Disposed HITs are not returned in results for the ListHITs operation. 
    /// </para></li><li><para>
    ///  Disposing HITs can improve the performance of operations such as ListReviewableHITs
    /// and ListHITs. 
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Remove", "MTRHIT", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service DeleteHIT API operation.", Operation = new[] {"DeleteHIT"}, SelectReturnType = typeof(Amazon.MTurk.Model.DeleteHITResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.DeleteHITResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.DeleteHITResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveMTRHITCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The ID of the HIT to be deleted.</para>
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
        public System.String HITId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.DeleteHITResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HITId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HITId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HITId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HITId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MTRHIT (DeleteHIT)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.DeleteHITResponse, RemoveMTRHITCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HITId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HITId = this.HITId;
            #if MODULAR
            if (this.HITId == null && ParameterWasBound(nameof(this.HITId)))
            {
                WriteWarning("You are passing $null as a value for parameter HITId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.DeleteHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
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
        
        private Amazon.MTurk.Model.DeleteHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.DeleteHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "DeleteHIT");
            try
            {
                #if DESKTOP
                return client.DeleteHIT(request);
                #elif CORECLR
                return client.DeleteHITAsync(request).GetAwaiter().GetResult();
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
            public System.String HITId { get; set; }
            public System.Func<Amazon.MTurk.Model.DeleteHITResponse, RemoveMTRHITCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
