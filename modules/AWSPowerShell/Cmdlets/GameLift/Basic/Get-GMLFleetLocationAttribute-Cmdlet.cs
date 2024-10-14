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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves information on a fleet's remote locations, including life-cycle status and
    /// any suspended fleet activity. 
    /// 
    ///  
    /// <para>
    /// This operation can be used in the following ways: 
    /// </para><ul><li><para>
    /// To get data for specific locations, provide a fleet identifier and a list of locations.
    /// Location data is returned in the order that it is requested. 
    /// </para></li><li><para>
    /// To get data for all locations, provide a fleet identifier only. Location data is returned
    /// in no particular order. 
    /// </para></li></ul><para>
    /// When requesting attributes for multiple locations, use the pagination parameters to
    /// retrieve results as a set of sequential pages. 
    /// </para><para>
    /// If successful, a <c>LocationAttributes</c> object is returned for each requested location.
    /// If the fleet does not have a requested location, no information is returned. This
    /// operation does not return the home Region. To get information on a fleet's home Region,
    /// call <c>DescribeFleetAttributes</c>.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up Amazon GameLift fleets</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-regions.html">
    /// Amazon GameLift service locations</a> for managed hosting
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GMLFleetLocationAttribute")]
    [OutputType("Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeFleetLocationAttributes API operation.", Operation = new[] {"DescribeFleetLocationAttributes"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse",
        "This cmdlet returns an Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse object containing multiple properties."
    )]
    public partial class GetGMLFleetLocationAttributeCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to retrieve remote locations for. You can use either
        /// the fleet ID or ARN value.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A list of fleet locations to retrieve information for. Specify locations in the form
        /// of an Amazon Web Services Region code, such as <c>us-west-2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Locations")]
        public System.String[] Location { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <c>NextToken</c>
        /// to get results as a set of sequential pages. This limit is not currently enforced.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates the start of the next sequential page of results. Use the token
        /// that is returned with a previous call to this operation. To start at the beginning
        /// of the result set, do not specify a value.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse, GetGMLFleetLocationAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Limit = this.Limit;
            if (this.Location != null)
            {
                context.Location = new List<System.String>(this.Location);
            }
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.GameLift.Model.DescribeFleetLocationAttributesRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.Location != null)
            {
                request.Locations = cmdletContext.Location;
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
        
        private Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeFleetLocationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeFleetLocationAttributes");
            try
            {
                #if DESKTOP
                return client.DescribeFleetLocationAttributes(request);
                #elif CORECLR
                return client.DescribeFleetLocationAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String FleetId { get; set; }
            public System.Int32? Limit { get; set; }
            public List<System.String> Location { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeFleetLocationAttributesResponse, GetGMLFleetLocationAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
