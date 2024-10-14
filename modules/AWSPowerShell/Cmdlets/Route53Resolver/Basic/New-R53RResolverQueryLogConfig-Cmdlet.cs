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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Creates a Resolver query logging configuration, which defines where you want Resolver
    /// to save DNS query logs that originate in your VPCs. Resolver can log queries only
    /// for VPCs that are in the same Region as the query logging configuration.
    /// 
    ///  
    /// <para>
    /// To specify which VPCs you want to log queries for, you use <c>AssociateResolverQueryLogConfig</c>.
    /// For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_route53resolver_AssociateResolverQueryLogConfig.html">AssociateResolverQueryLogConfig</a>.
    /// 
    /// </para><para>
    /// You can optionally use Resource Access Manager (RAM) to share a query logging configuration
    /// with other Amazon Web Services accounts. The other accounts can then associate VPCs
    /// with the configuration. The query logs that Resolver creates for a configuration include
    /// all DNS queries that originate in all VPCs that are associated with the configuration.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53RResolverQueryLogConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverQueryLogConfig")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver CreateResolverQueryLogConfig API operation.", Operation = new[] {"CreateResolverQueryLogConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverQueryLogConfig or Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverQueryLogConfig object.",
        "The service call response (type Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewR53RResolverQueryLogConfigCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed requests to be
        /// retried without the risk of running the operation twice. <c>CreatorRequestId</c> can
        /// be any unique string, for example, a date/time stamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource that you want Resolver to send query logs. You can send query
        /// logs to an S3 bucket, a CloudWatch Logs log group, or a Kinesis Data Firehose delivery
        /// stream. Examples of valid values include the following:</para><ul><li><para><b>S3 bucket</b>: </para><para><c>arn:aws:s3:::amzn-s3-demo-bucket</c></para><para>You can optionally append a file prefix to the end of the ARN.</para><para><c>arn:aws:s3:::amzn-s3-demo-bucket/development/</c></para></li><li><para><b>CloudWatch Logs log group</b>: </para><para><c>arn:aws:logs:us-west-1:123456789012:log-group:/mystack-testgroup-12ABC1AB12A1:*</c></para></li><li><para><b>Kinesis Data Firehose delivery stream</b>:</para><para><c>arn:aws:kinesis:us-east-2:0123456789:stream/my_stream_name</c></para></li></ul>
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
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name that you want to give the query logging configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of the tag keys and values that you want to associate with the query logging
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Route53Resolver.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverQueryLogConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverQueryLogConfig";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RResolverQueryLogConfig (CreateResolverQueryLogConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse, NewR53RResolverQueryLogConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.DestinationArn = this.DestinationArn;
            #if MODULAR
            if (this.DestinationArn == null && ParameterWasBound(nameof(this.DestinationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Route53Resolver.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "CreateResolverQueryLogConfig");
            try
            {
                #if DESKTOP
                return client.CreateResolverQueryLogConfig(request);
                #elif CORECLR
                return client.CreateResolverQueryLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String CreatorRequestId { get; set; }
            public System.String DestinationArn { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Route53Resolver.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.CreateResolverQueryLogConfigResponse, NewR53RResolverQueryLogConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverQueryLogConfig;
        }
        
    }
}
