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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>CreateAdditionalAssignmentsForHIT</code> operation increases the maximum
    /// number of assignments of an existing HIT. 
    /// 
    ///  
    /// <para>
    ///  To extend the maximum number of assignments, specify the number of additional assignments.
    /// </para><note><ul><li><para>
    /// HITs created with fewer than 10 assignments cannot be extended to have 10 or more
    /// assignments. Attempting to add assignments in a way that brings the total number of
    /// assignments for a HIT from fewer than 10 assignments to 10 or more assignments will
    /// result in an <code>AWS.MechanicalTurk.InvalidMaximumAssignmentsIncrease</code> exception.
    /// </para></li><li><para>
    /// HITs that were created before July 22, 2015 cannot be extended. Attempting to extend
    /// HITs that were created before July 22, 2015 will result in an <code>AWS.MechanicalTurk.HITTooOldForExtension</code>
    /// exception. 
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "MTRAdditionalAssignmentsForHIT", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service CreateAdditionalAssignmentsForHIT API operation.", Operation = new[] {"CreateAdditionalAssignmentsForHIT"}, SelectReturnType = typeof(Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMTRAdditionalAssignmentsForHITCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The ID of the HIT to extend.</para>
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
        
        #region Parameter NumberOfAdditionalAssignment
        /// <summary>
        /// <para>
        /// <para>The number of additional assignments to request for this HIT.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberOfAdditionalAssignments")]
        public System.Int32? NumberOfAdditionalAssignment { get; set; }
        #endregion
        
        #region Parameter UniqueRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for this request, which allows you to retry the call on error
        /// without extending the HIT multiple times. This is useful in cases such as network
        /// timeouts where it is unclear whether or not the call succeeded on the server. If the
        /// extend HIT already exists in the system from a previous call using the same <code>UniqueRequestToken</code>,
        /// subsequent calls will return an error with a message containing the request ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UniqueRequestToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HITId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRAdditionalAssignmentsForHIT (CreateAdditionalAssignmentsForHIT)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse, NewMTRAdditionalAssignmentsForHITCmdlet>(Select) ??
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
            context.NumberOfAdditionalAssignment = this.NumberOfAdditionalAssignment;
            #if MODULAR
            if (this.NumberOfAdditionalAssignment == null && ParameterWasBound(nameof(this.NumberOfAdditionalAssignment)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberOfAdditionalAssignment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UniqueRequestToken = this.UniqueRequestToken;
            
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
            var request = new Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
            }
            if (cmdletContext.NumberOfAdditionalAssignment != null)
            {
                request.NumberOfAdditionalAssignments = cmdletContext.NumberOfAdditionalAssignment.Value;
            }
            if (cmdletContext.UniqueRequestToken != null)
            {
                request.UniqueRequestToken = cmdletContext.UniqueRequestToken;
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
        
        private Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateAdditionalAssignmentsForHIT");
            try
            {
                #if DESKTOP
                return client.CreateAdditionalAssignmentsForHIT(request);
                #elif CORECLR
                return client.CreateAdditionalAssignmentsForHITAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? NumberOfAdditionalAssignment { get; set; }
            public System.String UniqueRequestToken { get; set; }
            public System.Func<Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse, NewMTRAdditionalAssignmentsForHITCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
