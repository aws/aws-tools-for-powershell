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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets the specified limit for a specified hosted zone, for example, the maximum number
    /// of records that you can create in the hosted zone. 
    /// 
    ///  
    /// <para>
    /// For the default limit, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html">Limits</a>
    /// in the <i>Amazon Route 53 Developer Guide</i>. To request a higher limit, <a href="https://console.aws.amazon.com/support/home#/case/create?issueType=service-limit-increase&amp;limitType=service-code-route53">open
    /// a case</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53HostedZoneLimit")]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the Amazon Route 53 GetHostedZoneLimit API operation.", Operation = new[] {"GetHostedZoneLimit"}, SelectReturnType = typeof(Amazon.Route53.Model.GetHostedZoneLimitResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.Route53.Model.GetHostedZoneLimitResponse",
        "This cmdlet returns a System.Int64 object.",
        "The service call response (type Amazon.Route53.Model.GetHostedZoneLimitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53HostedZoneLimitCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want to get a limit for.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The limit that you want to get. Valid values include the following:</para><ul><li><para><b>MAX_RRSETS_BY_ZONE</b>: The maximum number of records that you can create in the
        /// specified hosted zone.</para></li><li><para><b>MAX_VPCS_ASSOCIATED_BY_ZONE</b>: The maximum number of Amazon VPCs that you can
        /// associate with the specified private hosted zone.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53.HostedZoneLimitType")]
        public Amazon.Route53.HostedZoneLimitType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Limit.Value'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.GetHostedZoneLimitResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.GetHostedZoneLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Limit.Value";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HostedZoneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.GetHostedZoneLimitResponse, GetR53HostedZoneLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HostedZoneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.GetHostedZoneLimitRequest();
            
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
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
        
        private Amazon.Route53.Model.GetHostedZoneLimitResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetHostedZoneLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetHostedZoneLimit");
            try
            {
                #if DESKTOP
                return client.GetHostedZoneLimit(request);
                #elif CORECLR
                return client.GetHostedZoneLimitAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Route53.HostedZoneLimitType Type { get; set; }
            public System.String HostedZoneId { get; set; }
            public System.Func<Amazon.Route53.Model.GetHostedZoneLimitResponse, GetR53HostedZoneLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Limit.Value;
        }
        
    }
}
