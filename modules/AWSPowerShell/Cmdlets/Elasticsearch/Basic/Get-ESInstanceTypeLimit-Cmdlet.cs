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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Describe Elasticsearch Limits for a given InstanceType and ElasticsearchVersion.
    /// When modifying existing Domain, specify the <c><a>DomainName</a></c> to know what
    /// Limits are supported for modifying.
    /// </summary>
    [Cmdlet("Get", "ESInstanceTypeLimit")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elasticsearch DescribeElasticsearchInstanceTypeLimits API operation.", Operation = new[] {"DescribeElasticsearchInstanceTypeLimits"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetESInstanceTypeLimitCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para> DomainName represents the name of the Domain that we are trying to modify. This should
        /// be present only if we are querying for Elasticsearch <c><a>Limits</a></c> for existing
        /// domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchVersion
        /// <summary>
        /// <para>
        /// <para> Version of Elasticsearch for which <c><a>Limits</a></c> are needed. </para>
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
        public System.String ElasticsearchVersion { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The instance type for an Elasticsearch cluster for which Elasticsearch <c><a>Limits</a></c> are needed. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LimitsByRole'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LimitsByRole";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse, GetESInstanceTypeLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainName = this.DomainName;
            context.ElasticsearchVersion = this.ElasticsearchVersion;
            #if MODULAR
            if (this.ElasticsearchVersion == null && ParameterWasBound(nameof(this.ElasticsearchVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ElasticsearchVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ElasticsearchVersion != null)
            {
                request.ElasticsearchVersion = cmdletContext.ElasticsearchVersion;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
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
        
        private Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "DescribeElasticsearchInstanceTypeLimits");
            try
            {
                #if DESKTOP
                return client.DescribeElasticsearchInstanceTypeLimits(request);
                #elif CORECLR
                return client.DescribeElasticsearchInstanceTypeLimitsAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String ElasticsearchVersion { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType InstanceType { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse, GetESInstanceTypeLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LimitsByRole;
        }
        
    }
}
