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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Aggregates on indexed data with search queries pertaining to particular fields. 
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">GetBucketsAggregation</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTBucketsAggregation")]
    [OutputType("Amazon.IoT.Model.GetBucketsAggregationResponse")]
    [AWSCmdlet("Calls the AWS IoT GetBucketsAggregation API operation.", Operation = new[] {"GetBucketsAggregation"}, SelectReturnType = typeof(Amazon.IoT.Model.GetBucketsAggregationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.GetBucketsAggregationResponse",
        "This cmdlet returns an Amazon.IoT.Model.GetBucketsAggregationResponse object containing multiple properties."
    )]
    public partial class GetIOTBucketsAggregationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AggregationField
        /// <summary>
        /// <para>
        /// <para>The aggregation field.</para>
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
        public System.String AggregationField { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the index to search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter TermsAggregation_MaxBucket
        /// <summary>
        /// <para>
        /// <para>The number of buckets to return in the response. Default to 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BucketsAggregationType_TermsAggregation_MaxBuckets")]
        public System.Int32? TermsAggregation_MaxBucket { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The search query string.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter QueryVersion
        /// <summary>
        /// <para>
        /// <para>The version of the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.GetBucketsAggregationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.GetBucketsAggregationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.GetBucketsAggregationResponse, GetIOTBucketsAggregationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregationField = this.AggregationField;
            #if MODULAR
            if (this.AggregationField == null && ParameterWasBound(nameof(this.AggregationField)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregationField which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TermsAggregation_MaxBucket = this.TermsAggregation_MaxBucket;
            context.IndexName = this.IndexName;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryVersion = this.QueryVersion;
            
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
            var request = new Amazon.IoT.Model.GetBucketsAggregationRequest();
            
            if (cmdletContext.AggregationField != null)
            {
                request.AggregationField = cmdletContext.AggregationField;
            }
            
             // populate BucketsAggregationType
            request.BucketsAggregationType = new Amazon.IoT.Model.BucketsAggregationType();
            Amazon.IoT.Model.TermsAggregation requestBucketsAggregationType_bucketsAggregationType_TermsAggregation = null;
            
             // populate TermsAggregation
            var requestBucketsAggregationType_bucketsAggregationType_TermsAggregationIsNull = true;
            requestBucketsAggregationType_bucketsAggregationType_TermsAggregation = new Amazon.IoT.Model.TermsAggregation();
            System.Int32? requestBucketsAggregationType_bucketsAggregationType_TermsAggregation_termsAggregation_MaxBucket = null;
            if (cmdletContext.TermsAggregation_MaxBucket != null)
            {
                requestBucketsAggregationType_bucketsAggregationType_TermsAggregation_termsAggregation_MaxBucket = cmdletContext.TermsAggregation_MaxBucket.Value;
            }
            if (requestBucketsAggregationType_bucketsAggregationType_TermsAggregation_termsAggregation_MaxBucket != null)
            {
                requestBucketsAggregationType_bucketsAggregationType_TermsAggregation.MaxBuckets = requestBucketsAggregationType_bucketsAggregationType_TermsAggregation_termsAggregation_MaxBucket.Value;
                requestBucketsAggregationType_bucketsAggregationType_TermsAggregationIsNull = false;
            }
             // determine if requestBucketsAggregationType_bucketsAggregationType_TermsAggregation should be set to null
            if (requestBucketsAggregationType_bucketsAggregationType_TermsAggregationIsNull)
            {
                requestBucketsAggregationType_bucketsAggregationType_TermsAggregation = null;
            }
            if (requestBucketsAggregationType_bucketsAggregationType_TermsAggregation != null)
            {
                request.BucketsAggregationType.TermsAggregation = requestBucketsAggregationType_bucketsAggregationType_TermsAggregation;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            if (cmdletContext.QueryVersion != null)
            {
                request.QueryVersion = cmdletContext.QueryVersion;
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
        
        private Amazon.IoT.Model.GetBucketsAggregationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.GetBucketsAggregationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "GetBucketsAggregation");
            try
            {
                return client.GetBucketsAggregationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AggregationField { get; set; }
            public System.Int32? TermsAggregation_MaxBucket { get; set; }
            public System.String IndexName { get; set; }
            public System.String QueryString { get; set; }
            public System.String QueryVersion { get; set; }
            public System.Func<Amazon.IoT.Model.GetBucketsAggregationResponse, GetIOTBucketsAggregationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
