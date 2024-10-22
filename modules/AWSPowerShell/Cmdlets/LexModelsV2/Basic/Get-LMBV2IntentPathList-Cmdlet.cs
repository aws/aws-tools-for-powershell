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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Retrieves summary statistics for a path of intents that users take over sessions with
    /// your bot. The following fields are required:
    /// 
    ///  <ul><li><para><c>startDateTime</c> and <c>endDateTime</c> – Define a time range for which you want
    /// to retrieve results.
    /// </para></li><li><para><c>intentPath</c> – Define an order of intents for which you want to retrieve metrics.
    /// Separate intents in the path with a forward slash. For example, populate the <c>intentPath</c>
    /// field with <c>/BookCar/BookHotel</c> to see details about how many times users invoked
    /// the <c>BookCar</c> and <c>BookHotel</c> intents in that order.
    /// </para></li></ul><para>
    /// Use the optional <c>filters</c> field to filter the results.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBV2IntentPathList")]
    [OutputType("Amazon.LexModelsV2.Model.AnalyticsIntentNodeSummary")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListIntentPaths API operation.", Operation = new[] {"ListIntentPaths"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListIntentPathsResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.AnalyticsIntentNodeSummary or Amazon.LexModelsV2.Model.ListIntentPathsResponse",
        "This cmdlet returns a collection of Amazon.LexModelsV2.Model.AnalyticsIntentNodeSummary objects.",
        "The service call response (type Amazon.LexModelsV2.Model.ListIntentPathsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLMBV2IntentPathListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier for the bot for which you want to retrieve intent path metrics.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter EndDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time that marks the end of the range of time for which you want to see
        /// intent path metrics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndDateTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A list of objects, each describes a condition by which you want to filter the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LexModelsV2.Model.AnalyticsPathFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter IntentPath
        /// <summary>
        /// <para>
        /// <para>The intent path for which you want to retrieve metrics. Use a forward slash to separate
        /// intents in the path. For example:</para><ul><li><para>/BookCar</para></li><li><para>/BookCar/BookHotel</para></li><li><para>/BookHotel/BookCar</para></li></ul>
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
        public System.String IntentPath { get; set; }
        #endregion
        
        #region Parameter StartDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time that marks the beginning of the range of time for which you want
        /// to see intent path metrics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartDateTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NodeSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListIntentPathsResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListIntentPathsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NodeSummaries";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListIntentPathsResponse, GetLMBV2IntentPathListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDateTime = this.EndDateTime;
            #if MODULAR
            if (this.EndDateTime == null && ParameterWasBound(nameof(this.EndDateTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndDateTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LexModelsV2.Model.AnalyticsPathFilter>(this.Filter);
            }
            context.IntentPath = this.IntentPath;
            #if MODULAR
            if (this.IntentPath == null && ParameterWasBound(nameof(this.IntentPath)))
            {
                WriteWarning("You are passing $null as a value for parameter IntentPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartDateTime = this.StartDateTime;
            #if MODULAR
            if (this.StartDateTime == null && ParameterWasBound(nameof(this.StartDateTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartDateTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelsV2.Model.ListIntentPathsRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.EndDateTime != null)
            {
                request.EndDateTime = cmdletContext.EndDateTime.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IntentPath != null)
            {
                request.IntentPath = cmdletContext.IntentPath;
            }
            if (cmdletContext.StartDateTime != null)
            {
                request.StartDateTime = cmdletContext.StartDateTime.Value;
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
        
        private Amazon.LexModelsV2.Model.ListIntentPathsResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListIntentPathsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListIntentPaths");
            try
            {
                #if DESKTOP
                return client.ListIntentPaths(request);
                #elif CORECLR
                return client.ListIntentPathsAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.DateTime? EndDateTime { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsPathFilter> Filter { get; set; }
            public System.String IntentPath { get; set; }
            public System.DateTime? StartDateTime { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListIntentPathsResponse, GetLMBV2IntentPathListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NodeSummaries;
        }
        
    }
}
