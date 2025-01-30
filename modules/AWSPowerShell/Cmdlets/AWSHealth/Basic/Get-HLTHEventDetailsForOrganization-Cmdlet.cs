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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns detailed information about one or more specified events for one or more Amazon
    /// Web Services accounts in your organization. This information includes standard event
    /// data (such as the Amazon Web Services Region and service), an event description, and
    /// (depending on the event) possible metadata. This operation doesn't return affected
    /// entities, such as the resources related to the event. To return affected entities,
    /// use the <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_DescribeAffectedEntitiesForOrganization.html">DescribeAffectedEntitiesForOrganization</a>
    /// operation.
    /// 
    ///  <note><para>
    /// Before you can call this operation, you must first enable Health to work with Organizations.
    /// To do this, call the <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_EnableHealthServiceAccessForOrganization.html">EnableHealthServiceAccessForOrganization</a>
    /// operation from your organization's management account.
    /// </para></note><para>
    /// When you call the <c>DescribeEventDetailsForOrganization</c> operation, specify the
    /// <c>organizationEventDetailFilters</c> object in the request. Depending on the Health
    /// event type, note the following differences:
    /// </para><ul><li><para>
    /// To return event details for a public event, you must specify a null value for the
    /// <c>awsAccountId</c> parameter. If you specify an account ID for a public event, Health
    /// returns an error message because public events aren't specific to an account.
    /// </para></li><li><para>
    /// To return event details for an event that is specific to an account in your organization,
    /// you must specify the <c>awsAccountId</c> parameter in the request. If you don't specify
    /// an account ID, Health returns an error message because the event is specific to an
    /// account in your organization. 
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_Event.html">Event</a>.
    /// </para><note><para>
    /// This operation doesn't support resource-level permissions. You can't use this operation
    /// to allow or deny access to specific Health events. For more information, see <a href="https://docs.aws.amazon.com/health/latest/ug/security_iam_id-based-policy-examples.html#resource-action-based-conditions">Resource-
    /// and action-based conditions</a> in the <i>Health User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "HLTHEventDetailsForOrganization")]
    [OutputType("Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse")]
    [AWSCmdlet("Calls the AWS Health DescribeEventDetailsForOrganization API operation.", Operation = new[] {"DescribeEventDetailsForOrganization"}, SelectReturnType = typeof(Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse",
        "This cmdlet returns an Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse object containing multiple properties."
    )]
    public partial class GetHLTHEventDetailsForOrganizationCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale (language) to return information in. English (en) is the default and the
        /// only supported value at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter OrganizationEventDetailFilter
        /// <summary>
        /// <para>
        /// <para>A set of JSON elements that includes the <c>awsAccountId</c> and the <c>eventArn</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OrganizationEventDetailFilters")]
        public Amazon.AWSHealth.Model.EventAccountFilter[] OrganizationEventDetailFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Locale parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Locale' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Locale' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse, GetHLTHEventDetailsForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Locale;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Locale = this.Locale;
            if (this.OrganizationEventDetailFilter != null)
            {
                context.OrganizationEventDetailFilter = new List<Amazon.AWSHealth.Model.EventAccountFilter>(this.OrganizationEventDetailFilter);
            }
            #if MODULAR
            if (this.OrganizationEventDetailFilter == null && ParameterWasBound(nameof(this.OrganizationEventDetailFilter)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationEventDetailFilter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationRequest();
            
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.OrganizationEventDetailFilter != null)
            {
                request.OrganizationEventDetailFilters = cmdletContext.OrganizationEventDetailFilter;
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
        
        private Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEventDetailsForOrganization");
            try
            {
                #if DESKTOP
                return client.DescribeEventDetailsForOrganization(request);
                #elif CORECLR
                return client.DescribeEventDetailsForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.String Locale { get; set; }
            public List<Amazon.AWSHealth.Model.EventAccountFilter> OrganizationEventDetailFilter { get; set; }
            public System.Func<Amazon.AWSHealth.Model.DescribeEventDetailsForOrganizationResponse, GetHLTHEventDetailsForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
