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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Lists the data sets imported for a specific application. In Amazon Web Services Mainframe
    /// Modernization, data sets are associated with applications deployed on runtime environments.
    /// This is known as importing data sets. Currently, Amazon Web Services Mainframe Modernization
    /// can import data sets into catalogs using <a href="https://docs.aws.amazon.com/m2/latest/APIReference/API_CreateDataSetImportTask.html">CreateDataSetImportTask</a>.
    /// </summary>
    [Cmdlet("Get", "AMMDataSetList")]
    [OutputType("Amazon.MainframeModernization.Model.DataSetSummary")]
    [AWSCmdlet("Calls the M2 ListDataSets API operation.", Operation = new[] {"ListDataSets"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.ListDataSetsResponse))]
    [AWSCmdletOutput("Amazon.MainframeModernization.Model.DataSetSummary or Amazon.MainframeModernization.Model.ListDataSetsResponse",
        "This cmdlet returns a collection of Amazon.MainframeModernization.Model.DataSetSummary objects.",
        "The service call response (type Amazon.MainframeModernization.Model.ListDataSetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAMMDataSetListCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application for which you want to list the associated
        /// data sets.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter NameFilter
        /// <summary>
        /// <para>
        /// <para>Filter dataset name matching the specified pattern. Can use * and % as wild cards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NameFilter { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the data set name, which you can use to filter the list of data sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token returned from a previous call to this operation. This specifies
        /// the next item to return. To return to the beginning of the list, exclude this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.ListDataSetsResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.ListDataSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSets";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.ListDataSetsResponse, GetAMMDataSetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NameFilter = this.NameFilter;
            context.NextToken = this.NextToken;
            context.Prefix = this.Prefix;
            
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
            var request = new Amazon.MainframeModernization.Model.ListDataSetsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NameFilter != null)
            {
                request.NameFilter = cmdletContext.NameFilter;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
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
        
        private Amazon.MainframeModernization.Model.ListDataSetsResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.ListDataSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "ListDataSets");
            try
            {
                #if DESKTOP
                return client.ListDataSets(request);
                #elif CORECLR
                return client.ListDataSetsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NameFilter { get; set; }
            public System.String NextToken { get; set; }
            public System.String Prefix { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.ListDataSetsResponse, GetAMMDataSetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSets;
        }
        
    }
}
