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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Deprecates the specified <i>activity type</i>. After an activity type has been deprecated,
    /// you cannot create new tasks of that activity type. Tasks of this type that were scheduled
    /// before the type was deprecated continue to run.
    /// 
    ///  
    /// <para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <c>Condition</c> element with the appropriate
    /// keys.
    /// </para><ul><li><para><c>activityType.name</c>: String constraint. The key is <c>swf:activityType.name</c>.
    /// </para></li><li><para><c>activityType.version</c>: String constraint. The key is <c>swf:activityType.version</c>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SWFActivityType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) DeprecateActivityType API operation.", Operation = new[] {"DeprecateActivityType"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSWFActivityTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which the activity type is registered.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ActivityType_Name
        /// <summary>
        /// <para>
        /// <para>The name of this activity.</para><note><para>The combination of activity type name and version must be unique within a domain.</para></note>
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
        public System.String ActivityType_Name { get; set; }
        #endregion
        
        #region Parameter ActivityType_Version
        /// <summary>
        /// <para>
        /// <para>The version of this activity.</para><note><para>The combination of activity type name and version must be unique with in a domain.</para></note>
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
        public System.String ActivityType_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ActivityType_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ActivityType_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ActivityType_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActivityType_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SWFActivityType (DeprecateActivityType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse, RemoveSWFActivityTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ActivityType_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActivityType_Name = this.ActivityType_Name;
            #if MODULAR
            if (this.ActivityType_Name == null && ParameterWasBound(nameof(this.ActivityType_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivityType_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActivityType_Version = this.ActivityType_Version;
            #if MODULAR
            if (this.ActivityType_Version == null && ParameterWasBound(nameof(this.ActivityType_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivityType_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.DeprecateActivityTypeRequest();
            
            
             // populate ActivityType
            var requestActivityTypeIsNull = true;
            request.ActivityType = new Amazon.SimpleWorkflow.Model.ActivityType();
            System.String requestActivityType_activityType_Name = null;
            if (cmdletContext.ActivityType_Name != null)
            {
                requestActivityType_activityType_Name = cmdletContext.ActivityType_Name;
            }
            if (requestActivityType_activityType_Name != null)
            {
                request.ActivityType.Name = requestActivityType_activityType_Name;
                requestActivityTypeIsNull = false;
            }
            System.String requestActivityType_activityType_Version = null;
            if (cmdletContext.ActivityType_Version != null)
            {
                requestActivityType_activityType_Version = cmdletContext.ActivityType_Version;
            }
            if (requestActivityType_activityType_Version != null)
            {
                request.ActivityType.Version = requestActivityType_activityType_Version;
                requestActivityTypeIsNull = false;
            }
             // determine if request.ActivityType should be set to null
            if (requestActivityTypeIsNull)
            {
                request.ActivityType = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
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
        
        private Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.DeprecateActivityTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "DeprecateActivityType");
            try
            {
                #if DESKTOP
                return client.DeprecateActivityType(request);
                #elif CORECLR
                return client.DeprecateActivityTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String ActivityType_Name { get; set; }
            public System.String ActivityType_Version { get; set; }
            public System.String Domain { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.DeprecateActivityTypeResponse, RemoveSWFActivityTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
