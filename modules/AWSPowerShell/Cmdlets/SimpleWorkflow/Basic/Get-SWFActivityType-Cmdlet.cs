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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns information about the specified activity type. This includes configuration
    /// settings provided when the type was registered and other general information about
    /// the type.
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
    [Cmdlet("Get", "SWFActivityType")]
    [OutputType("Amazon.SimpleWorkflow.Model.ActivityTypeDetail")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) DescribeActivityType API operation.", Operation = new[] {"DescribeActivityType"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.ActivityTypeDetail or Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse",
        "This cmdlet returns an Amazon.SimpleWorkflow.Model.ActivityTypeDetail object.",
        "The service call response (type Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSWFActivityTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ActivityTypeDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ActivityTypeDetail";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse, GetSWFActivityTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.SimpleWorkflow.Model.DescribeActivityTypeRequest();
            
            
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
        
        private Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.DescribeActivityTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "DescribeActivityType");
            try
            {
                return client.DescribeActivityTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse, GetSWFActivityTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ActivityTypeDetail;
        }
        
    }
}
