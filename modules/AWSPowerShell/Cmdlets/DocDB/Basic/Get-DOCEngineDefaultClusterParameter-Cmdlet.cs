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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Returns the default engine and system parameter information for the cluster database
    /// engine.
    /// </summary>
    [Cmdlet("Get", "DOCEngineDefaultClusterParameter")]
    [OutputType("Amazon.DocDB.Model.EngineDefaults")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) DescribeEngineDefaultClusterParameters API operation.", Operation = new[] {"DescribeEngineDefaultClusterParameters"}, SelectReturnType = typeof(Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.EngineDefaults or Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse",
        "This cmdlet returns an Amazon.DocDB.Model.EngineDefaults object.",
        "The service call response (type Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDOCEngineDefaultClusterParameterCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of the cluster parameter group family to return the engine parameter information
        /// for.</para>
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
        public System.String DBParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.DocDB.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <c>MaxRecords</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token (marker) is included in
        /// the response so that the remaining results can be retrieved.</para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EngineDefaults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EngineDefaults";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBParameterGroupFamily parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBParameterGroupFamily' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBParameterGroupFamily' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse, GetDOCEngineDefaultClusterParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBParameterGroupFamily;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            #if MODULAR
            if (this.DBParameterGroupFamily == null && ParameterWasBound(nameof(this.DBParameterGroupFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter DBParameterGroupFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.DocDB.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
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
            var request = new Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersRequest();
            
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
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
        
        private Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "DescribeEngineDefaultClusterParameters");
            try
            {
                #if DESKTOP
                return client.DescribeEngineDefaultClusterParameters(request);
                #elif CORECLR
                return client.DescribeEngineDefaultClusterParametersAsync(request).GetAwaiter().GetResult();
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
            public System.String DBParameterGroupFamily { get; set; }
            public List<Amazon.DocDB.Model.Filter> Filter { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.DocDB.Model.DescribeEngineDefaultClusterParametersResponse, GetDOCEngineDefaultClusterParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EngineDefaults;
        }
        
    }
}
