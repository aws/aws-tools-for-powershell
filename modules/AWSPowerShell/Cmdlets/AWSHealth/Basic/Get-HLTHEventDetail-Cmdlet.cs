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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns detailed information about one or more specified events. Information includes
    /// standard event data (Amazon Web Services Region, service, and so on, as returned by
    /// <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_DescribeEvents.html">DescribeEvents</a>),
    /// a detailed event description, and possible additional metadata that depends upon the
    /// nature of the event. Affected entities are not included. To retrieve the entities,
    /// use the <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_DescribeAffectedEntities.html">DescribeAffectedEntities</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// If a specified event can't be retrieved, an error message is returned for that event.
    /// </para><note><para>
    /// This operation supports resource-level permissions. You can use this operation to
    /// allow or deny access to specific Health events. For more information, see <a href="https://docs.aws.amazon.com/health/latest/ug/security_iam_id-based-policy-examples.html#resource-action-based-conditions">Resource-
    /// and action-based conditions</a> in the <i>Health User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "HLTHEventDetail")]
    [OutputType("Amazon.AWSHealth.Model.DescribeEventDetailsResponse")]
    [AWSCmdlet("Calls the AWS Health DescribeEventDetails API operation.", Operation = new[] {"DescribeEventDetails"}, SelectReturnType = typeof(Amazon.AWSHealth.Model.DescribeEventDetailsResponse))]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.DescribeEventDetailsResponse",
        "This cmdlet returns an Amazon.AWSHealth.Model.DescribeEventDetailsResponse object containing multiple properties."
    )]
    public partial class GetHLTHEventDetailCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventArn
        /// <summary>
        /// <para>
        /// <para>A list of event ARNs (unique identifiers). For example: <c>"arn:aws:health:us-east-1::event/EC2/EC2_INSTANCE_RETIREMENT_SCHEDULED/EC2_INSTANCE_RETIREMENT_SCHEDULED_ABC123-CDE456",
        /// "arn:aws:health:us-west-1::event/EBS/AWS_EBS_LOST_VOLUME/AWS_EBS_LOST_VOLUME_CHI789_JKL101"</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EventArns")]
        public System.String[] EventArn { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale (language) to return information in. English (en) is the default and the
        /// only supported value at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSHealth.Model.DescribeEventDetailsResponse).
        /// Specifying the name of a property of type Amazon.AWSHealth.Model.DescribeEventDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.AWSHealth.Model.DescribeEventDetailsResponse, GetHLTHEventDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EventArn != null)
            {
                context.EventArn = new List<System.String>(this.EventArn);
            }
            #if MODULAR
            if (this.EventArn == null && ParameterWasBound(nameof(this.EventArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            
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
            var request = new Amazon.AWSHealth.Model.DescribeEventDetailsRequest();
            
            if (cmdletContext.EventArn != null)
            {
                request.EventArns = cmdletContext.EventArn;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
        
        private Amazon.AWSHealth.Model.DescribeEventDetailsResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEventDetails");
            try
            {
                #if DESKTOP
                return client.DescribeEventDetails(request);
                #elif CORECLR
                return client.DescribeEventDetailsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> EventArn { get; set; }
            public System.String Locale { get; set; }
            public System.Func<Amazon.AWSHealth.Model.DescribeEventDetailsResponse, GetHLTHEventDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
