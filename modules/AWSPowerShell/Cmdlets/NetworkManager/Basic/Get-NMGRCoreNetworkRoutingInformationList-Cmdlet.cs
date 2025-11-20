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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Lists routing information for a core network, including routes and their attributes.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "NMGRCoreNetworkRoutingInformationList")]
    [OutputType("Amazon.NetworkManager.Model.CoreNetworkRoutingInformation")]
    [AWSCmdlet("Calls the AWS Network Manager ListCoreNetworkRoutingInformation API operation.", Operation = new[] {"ListCoreNetworkRoutingInformation"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.CoreNetworkRoutingInformation or Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse",
        "This cmdlet returns a collection of Amazon.NetworkManager.Model.CoreNetworkRoutingInformation objects.",
        "The service call response (type Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNMGRCoreNetworkRoutingInformationListCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CommunityMatch
        /// <summary>
        /// <para>
        /// <para>BGP community values to match when filtering routing information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommunityMatches")]
        public System.String[] CommunityMatch { get; set; }
        #endregion
        
        #region Parameter CoreNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the core network to retrieve routing information for.</para>
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
        public System.String CoreNetworkId { get; set; }
        #endregion
        
        #region Parameter EdgeLocation
        /// <summary>
        /// <para>
        /// <para>The edge location to filter routing information by.</para>
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
        public System.String EdgeLocation { get; set; }
        #endregion
        
        #region Parameter ExactAsPathMatch
        /// <summary>
        /// <para>
        /// <para>Exact AS path values to match when filtering routing information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExactAsPathMatches")]
        public System.String[] ExactAsPathMatch { get; set; }
        #endregion
        
        #region Parameter LocalPreferenceMatch
        /// <summary>
        /// <para>
        /// <para>Local preference values to match when filtering routing information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LocalPreferenceMatches")]
        public System.String[] LocalPreferenceMatch { get; set; }
        #endregion
        
        #region Parameter MedMatch
        /// <summary>
        /// <para>
        /// <para>Multi-Exit Discriminator (MED) values to match when filtering routing information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MedMatches")]
        public System.String[] MedMatch { get; set; }
        #endregion
        
        #region Parameter NextHopFilter
        /// <summary>
        /// <para>
        /// <para>Filters to apply based on next hop information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextHopFilters")]
        public System.Collections.Hashtable NextHopFilter { get; set; }
        #endregion
        
        #region Parameter SegmentName
        /// <summary>
        /// <para>
        /// <para>The name of the segment to filter routing information by.</para>
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
        public System.String SegmentName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of routing information entries to return in a single page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CoreNetworkRoutingInformation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CoreNetworkRoutingInformation";
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
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse, GetNMGRCoreNetworkRoutingInformationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CommunityMatch != null)
            {
                context.CommunityMatch = new List<System.String>(this.CommunityMatch);
            }
            context.CoreNetworkId = this.CoreNetworkId;
            #if MODULAR
            if (this.CoreNetworkId == null && ParameterWasBound(nameof(this.CoreNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EdgeLocation = this.EdgeLocation;
            #if MODULAR
            if (this.EdgeLocation == null && ParameterWasBound(nameof(this.EdgeLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter EdgeLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExactAsPathMatch != null)
            {
                context.ExactAsPathMatch = new List<System.String>(this.ExactAsPathMatch);
            }
            if (this.LocalPreferenceMatch != null)
            {
                context.LocalPreferenceMatch = new List<System.String>(this.LocalPreferenceMatch);
            }
            context.MaxResult = this.MaxResult;
            if (this.MedMatch != null)
            {
                context.MedMatch = new List<System.String>(this.MedMatch);
            }
            if (this.NextHopFilter != null)
            {
                context.NextHopFilter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.NextHopFilter.Keys)
                {
                    object hashValue = this.NextHopFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.NextHopFilter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.NextHopFilter.Add((String)hashKey, valueSet);
                }
            }
            context.NextToken = this.NextToken;
            context.SegmentName = this.SegmentName;
            #if MODULAR
            if (this.SegmentName == null && ParameterWasBound(nameof(this.SegmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationRequest();
            
            if (cmdletContext.CommunityMatch != null)
            {
                request.CommunityMatches = cmdletContext.CommunityMatch;
            }
            if (cmdletContext.CoreNetworkId != null)
            {
                request.CoreNetworkId = cmdletContext.CoreNetworkId;
            }
            if (cmdletContext.EdgeLocation != null)
            {
                request.EdgeLocation = cmdletContext.EdgeLocation;
            }
            if (cmdletContext.ExactAsPathMatch != null)
            {
                request.ExactAsPathMatches = cmdletContext.ExactAsPathMatch;
            }
            if (cmdletContext.LocalPreferenceMatch != null)
            {
                request.LocalPreferenceMatches = cmdletContext.LocalPreferenceMatch;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MedMatch != null)
            {
                request.MedMatches = cmdletContext.MedMatch;
            }
            if (cmdletContext.NextHopFilter != null)
            {
                request.NextHopFilters = cmdletContext.NextHopFilter;
            }
            if (cmdletContext.SegmentName != null)
            {
                request.SegmentName = cmdletContext.SegmentName;
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
        
        private Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "ListCoreNetworkRoutingInformation");
            try
            {
                #if DESKTOP
                return client.ListCoreNetworkRoutingInformation(request);
                #elif CORECLR
                return client.ListCoreNetworkRoutingInformationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CommunityMatch { get; set; }
            public System.String CoreNetworkId { get; set; }
            public System.String EdgeLocation { get; set; }
            public List<System.String> ExactAsPathMatch { get; set; }
            public List<System.String> LocalPreferenceMatch { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> MedMatch { get; set; }
            public Dictionary<System.String, List<System.String>> NextHopFilter { get; set; }
            public System.String NextToken { get; set; }
            public System.String SegmentName { get; set; }
            public System.Func<Amazon.NetworkManager.Model.ListCoreNetworkRoutingInformationResponse, GetNMGRCoreNetworkRoutingInformationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CoreNetworkRoutingInformation;
        }
        
    }
}
