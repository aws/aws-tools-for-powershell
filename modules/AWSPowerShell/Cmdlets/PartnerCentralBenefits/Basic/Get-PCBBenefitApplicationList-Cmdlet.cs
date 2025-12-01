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
using Amazon.PartnerCentralBenefits;
using Amazon.PartnerCentralBenefits.Model;

namespace Amazon.PowerShell.Cmdlets.PCB
{
    /// <summary>
    /// Retrieves a paginated list of benefit applications based on specified filter criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PCBBenefitApplicationList")]
    [OutputType("Amazon.PartnerCentralBenefits.Model.BenefitApplicationSummary")]
    [AWSCmdlet("Calls the Amazon PartnerCentral Benefits Service ListBenefitApplications API operation.", Operation = new[] {"ListBenefitApplications"}, SelectReturnType = typeof(Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralBenefits.Model.BenefitApplicationSummary or Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralBenefits.Model.BenefitApplicationSummary objects.",
        "The service call response (type Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCBBenefitApplicationListCmdlet : AmazonPartnerCentralBenefitsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociatedResourceArn
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by specific AWS resource ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedResourceArns")]
        public System.String[] AssociatedResourceArn { get; set; }
        #endregion
        
        #region Parameter BenefitIdentifier
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by specific benefit identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BenefitIdentifiers")]
        public System.String[] BenefitIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier to filter benefit applications by catalog.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter FulfillmentType
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by specific fulfillment types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentTypes")]
        public System.String[] FulfillmentType { get; set; }
        #endregion
        
        #region Parameter Program
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by specific AWS partner programs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Programs")]
        public System.String[] Program { get; set; }
        #endregion
        
        #region Parameter Stage
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by their current processing stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Stages")]
        public System.String[] Stage { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by their current processing status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Status { get; set; }
        #endregion
        
        #region Parameter AssociatedResource
        /// <summary>
        /// <para>
        /// <para>Filter benefit applications by associated AWS resources.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is no longer used.")]
        [Alias("AssociatedResources")]
        public Amazon.PartnerCentralBenefits.Model.AssociatedResource[] AssociatedResource { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of benefit applications to return in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token to retrieve the next set of results from a previous request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BenefitApplicationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BenefitApplicationSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Catalog parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse, GetPCBBenefitApplicationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Catalog;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssociatedResourceArn != null)
            {
                context.AssociatedResourceArn = new List<System.String>(this.AssociatedResourceArn);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssociatedResource != null)
            {
                context.AssociatedResource = new List<Amazon.PartnerCentralBenefits.Model.AssociatedResource>(this.AssociatedResource);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BenefitIdentifier != null)
            {
                context.BenefitIdentifier = new List<System.String>(this.BenefitIdentifier);
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FulfillmentType != null)
            {
                context.FulfillmentType = new List<System.String>(this.FulfillmentType);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Program != null)
            {
                context.Program = new List<System.String>(this.Program);
            }
            if (this.Stage != null)
            {
                context.Stage = new List<System.String>(this.Stage);
            }
            if (this.Status != null)
            {
                context.Status = new List<System.String>(this.Status);
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsRequest();
            
            if (cmdletContext.AssociatedResourceArn != null)
            {
                request.AssociatedResourceArns = cmdletContext.AssociatedResourceArn;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AssociatedResource != null)
            {
                request.AssociatedResources = cmdletContext.AssociatedResource;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.BenefitIdentifier != null)
            {
                request.BenefitIdentifiers = cmdletContext.BenefitIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.FulfillmentType != null)
            {
                request.FulfillmentTypes = cmdletContext.FulfillmentType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Program != null)
            {
                request.Programs = cmdletContext.Program;
            }
            if (cmdletContext.Stage != null)
            {
                request.Stages = cmdletContext.Stage;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse CallAWSServiceOperation(IAmazonPartnerCentralBenefits client, Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon PartnerCentral Benefits Service", "ListBenefitApplications");
            try
            {
                #if DESKTOP
                return client.ListBenefitApplications(request);
                #elif CORECLR
                return client.ListBenefitApplicationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssociatedResourceArn { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.PartnerCentralBenefits.Model.AssociatedResource> AssociatedResource { get; set; }
            public List<System.String> BenefitIdentifier { get; set; }
            public System.String Catalog { get; set; }
            public List<System.String> FulfillmentType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Program { get; set; }
            public List<System.String> Stage { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.PartnerCentralBenefits.Model.ListBenefitApplicationsResponse, GetPCBBenefitApplicationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BenefitApplicationSummaries;
        }
        
    }
}
