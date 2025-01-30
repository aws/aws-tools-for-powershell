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
using Amazon.ForecastQueryService;
using Amazon.ForecastQueryService.Model;

namespace Amazon.PowerShell.Cmdlets.FRCQ
{
    /// <summary>
    /// Retrieves a what-if forecast.
    /// </summary>
    [Cmdlet("Select", "FRCQWhatIfForecast", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ForecastQueryService.Model.Forecast")]
    [AWSCmdlet("Calls the Amazon Forecast Query Service QueryWhatIfForecast API operation.", Operation = new[] {"QueryWhatIfForecast"}, SelectReturnType = typeof(Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse))]
    [AWSCmdletOutput("Amazon.ForecastQueryService.Model.Forecast or Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse",
        "This cmdlet returns an Amazon.ForecastQueryService.Model.Forecast object.",
        "The service call response (type Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SelectFRCQWhatIfForecastCmdlet : AmazonForecastQueryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The end date for the what-if forecast. Specify the date using this format: yyyy-MM-dd'T'HH:mm:ss
        /// (ISO 8601 format). For example, 2015-01-01T20:00:00. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndDate { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filtering criteria to apply when retrieving the forecast. For example, to get
        /// the forecast for <c>client_21</c> in the electricity usage dataset, specify the following:</para><para><c>{"item_id" : "client_21"}</c></para><para>To get the full what-if forecast, use the <a href="https://docs.aws.amazon.com/en_us/forecast/latest/dg/API_CreateWhatIfForecastExport.html">CreateForecastExportJob</a>
        /// operation.</para>
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
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The start date for the what-if forecast. Specify the date using this format: yyyy-MM-dd'T'HH:mm:ss
        /// (ISO 8601 format). For example, 2015-01-01T08:00:00.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartDate { get; set; }
        #endregion
        
        #region Parameter WhatIfForecastArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the what-if forecast to query.</para>
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
        public System.String WhatIfForecastArn { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the result of the previous request was truncated, the response includes a <c>NextToken</c>.
        /// To retrieve the next set of results, use the token in the next request. Tokens expire
        /// after 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Forecast'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse).
        /// Specifying the name of a property of type Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Forecast";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WhatIfForecastArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WhatIfForecastArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WhatIfForecastArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WhatIfForecastArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Select-FRCQWhatIfForecast (QueryWhatIfForecast)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse, SelectFRCQWhatIfForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WhatIfForecastArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndDate = this.EndDate;
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    context.Filter.Add((String)hashKey, (System.String)(this.Filter[hashKey]));
                }
            }
            #if MODULAR
            if (this.Filter == null && ParameterWasBound(nameof(this.Filter)))
            {
                WriteWarning("You are passing $null as a value for parameter Filter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.StartDate = this.StartDate;
            context.WhatIfForecastArn = this.WhatIfForecastArn;
            #if MODULAR
            if (this.WhatIfForecastArn == null && ParameterWasBound(nameof(this.WhatIfForecastArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastQueryService.Model.QueryWhatIfForecastRequest();
            
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate;
            }
            if (cmdletContext.WhatIfForecastArn != null)
            {
                request.WhatIfForecastArn = cmdletContext.WhatIfForecastArn;
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
        
        private Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse CallAWSServiceOperation(IAmazonForecastQueryService client, Amazon.ForecastQueryService.Model.QueryWhatIfForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Query Service", "QueryWhatIfForecast");
            try
            {
                #if DESKTOP
                return client.QueryWhatIfForecast(request);
                #elif CORECLR
                return client.QueryWhatIfForecastAsync(request).GetAwaiter().GetResult();
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
            public System.String EndDate { get; set; }
            public Dictionary<System.String, System.String> Filter { get; set; }
            public System.String NextToken { get; set; }
            public System.String StartDate { get; set; }
            public System.String WhatIfForecastArn { get; set; }
            public System.Func<Amazon.ForecastQueryService.Model.QueryWhatIfForecastResponse, SelectFRCQWhatIfForecastCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Forecast;
        }
        
    }
}
