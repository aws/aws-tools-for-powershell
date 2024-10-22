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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Gets the configuration options for the reserved-node exchange. These options include
    /// information about the source reserved node and target reserved node offering. Details
    /// include the node type, the price, the node count, and the offering type.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RSReservedNodeExchangeConfigurationOption")]
    [OutputType("Amazon.Redshift.Model.ReservedNodeConfigurationOption")]
    [AWSCmdlet("Calls the Amazon Redshift GetReservedNodeExchangeConfigurationOptions API operation.", Operation = new[] {"GetReservedNodeExchangeConfigurationOptions"}, SelectReturnType = typeof(Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ReservedNodeConfigurationOption or Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse",
        "This cmdlet returns a collection of Amazon.Redshift.Model.ReservedNodeConfigurationOption objects.",
        "The service call response (type Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSReservedNodeExchangeConfigurationOptionCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionType
        /// <summary>
        /// <para>
        /// <para>The action type of the reserved-node configuration. The action type can be an exchange
        /// initiated from either a snapshot or a resize.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Redshift.ReservedNodeExchangeActionType")]
        public Amazon.Redshift.ReservedNodeExchangeActionType ActionType { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster that is the source for a reserved-node exchange.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the snapshot that is the source for the reserved-node exchange.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <c>GetReservedNodeExchangeConfigurationOptions</c>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by the <c>MaxRecords</c> parameter. You can
        /// retrieve the next set of response records by providing the returned marker value in
        /// the <c>Marker</c> parameter and retrying the request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <c>MaxRecords</c> value, a value is returned
        /// in a <c>Marker</c> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedNodeConfigurationOptionList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedNodeConfigurationOptionList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse, GetRSReservedNodeExchangeConfigurationOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionType = this.ActionType;
            #if MODULAR
            if (this.ActionType == null && ParameterWasBound(nameof(this.ActionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            
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
            var request = new Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsRequest();
            
            if (cmdletContext.ActionType != null)
            {
                request.ActionType = cmdletContext.ActionType;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "GetReservedNodeExchangeConfigurationOptions");
            try
            {
                #if DESKTOP
                return client.GetReservedNodeExchangeConfigurationOptions(request);
                #elif CORECLR
                return client.GetReservedNodeExchangeConfigurationOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Redshift.ReservedNodeExchangeActionType ActionType { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.GetReservedNodeExchangeConfigurationOptionsResponse, GetRSReservedNodeExchangeConfigurationOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedNodeConfigurationOptionList;
        }
        
    }
}
