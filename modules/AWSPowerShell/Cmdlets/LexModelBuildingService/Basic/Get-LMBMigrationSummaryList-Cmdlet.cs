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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Gets a list of migrations between Amazon Lex V1 and Amazon Lex V2.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LMBMigrationSummaryList")]
    [OutputType("Amazon.LexModelBuildingService.Model.MigrationSummary")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service GetMigrations API operation.", Operation = new[] {"GetMigrations"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.GetMigrationsResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.MigrationSummary or Amazon.LexModelBuildingService.Model.GetMigrationsResponse",
        "This cmdlet returns a collection of Amazon.LexModelBuildingService.Model.MigrationSummary objects.",
        "The service call response (type Amazon.LexModelBuildingService.Model.GetMigrationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLMBMigrationSummaryListCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter MigrationStatusEqual
        /// <summary>
        /// <para>
        /// <para>Filters the list to contain only migrations in the specified state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MigrationStatusEquals")]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.MigrationStatus")]
        public Amazon.LexModelBuildingService.MigrationStatus MigrationStatusEqual { get; set; }
        #endregion
        
        #region Parameter SortByAttribute
        /// <summary>
        /// <para>
        /// <para>The field to sort the list of migrations by. You can sort by the Amazon Lex V1 bot
        /// name or the date and time that the migration was started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.MigrationSortAttribute")]
        public Amazon.LexModelBuildingService.MigrationSortAttribute SortByAttribute { get; set; }
        #endregion
        
        #region Parameter SortByOrder
        /// <summary>
        /// <para>
        /// <para>The order so sort the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.SortOrder")]
        public Amazon.LexModelBuildingService.SortOrder SortByOrder { get; set; }
        #endregion
        
        #region Parameter V1BotNameContain
        /// <summary>
        /// <para>
        /// <para>Filters the list to contain only bots whose name contains the specified string. The
        /// string is matched anywhere in bot name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("V1BotNameContains")]
        public System.String V1BotNameContain { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of migrations to return in the response. The default is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token that fetches the next page of migrations. If the response to this
        /// operation is truncated, Amazon Lex returns a pagination token in the response. To
        /// fetch the next page of migrations, specify the pagination token in the request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MigrationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.GetMigrationsResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.GetMigrationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MigrationSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.GetMigrationsResponse, GetLMBMigrationSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.MigrationStatusEqual = this.MigrationStatusEqual;
            context.NextToken = this.NextToken;
            context.SortByAttribute = this.SortByAttribute;
            context.SortByOrder = this.SortByOrder;
            context.V1BotNameContain = this.V1BotNameContain;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LexModelBuildingService.Model.GetMigrationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MigrationStatusEqual != null)
            {
                request.MigrationStatusEquals = cmdletContext.MigrationStatusEqual;
            }
            if (cmdletContext.SortByAttribute != null)
            {
                request.SortByAttribute = cmdletContext.SortByAttribute;
            }
            if (cmdletContext.SortByOrder != null)
            {
                request.SortByOrder = cmdletContext.SortByOrder;
            }
            if (cmdletContext.V1BotNameContain != null)
            {
                request.V1BotNameContains = cmdletContext.V1BotNameContain;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LexModelBuildingService.Model.GetMigrationsResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.GetMigrationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "GetMigrations");
            try
            {
                #if DESKTOP
                return client.GetMigrations(request);
                #elif CORECLR
                return client.GetMigrationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public Amazon.LexModelBuildingService.MigrationStatus MigrationStatusEqual { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelBuildingService.MigrationSortAttribute SortByAttribute { get; set; }
            public Amazon.LexModelBuildingService.SortOrder SortByOrder { get; set; }
            public System.String V1BotNameContain { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.GetMigrationsResponse, GetLMBMigrationSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MigrationSummaries;
        }
        
    }
}
