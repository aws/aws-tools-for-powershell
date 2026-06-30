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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Executes the stored query of an intermediate table to materialize data into managed
    /// storage. With this operation, you can perform initial population and subsequent refreshes.
    /// Each call creates a new version. The returned analysis ID can be tracked using <c>GetProtectedQuery</c>.
    /// Only the intermediate table owner can call this operation.
    /// </summary>
    [Cmdlet("Import", "CRSIntermediateTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.PopulateIntermediateTableResponse")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service PopulateIntermediateTable API operation.", Operation = new[] {"PopulateIntermediateTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.PopulateIntermediateTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.PopulateIntermediateTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.PopulateIntermediateTableResponse object containing multiple properties."
    )]
    public partial class ImportCRSIntermediateTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalysisPayerAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the member that pays for the analysis compute costs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalysisPayerAccountId { get; set; }
        #endregion
        
        #region Parameter IntermediateTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the intermediate table to populate.</para>
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
        public System.String IntermediateTableIdentifier { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership that contains the intermediate table.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_QueryComputeConfiguration_Number
        /// <summary>
        /// <para>
        /// <para> The number of workers.</para><para>SQL queries support a minimum value of 2 and a maximum value of 400. </para><para>PySpark jobs support a minimum value of 4 and a maximum value of 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_QueryComputeConfiguration_Number { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The runtime parameter values that override the defaults in the stored query.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_QueryComputeConfiguration_Properties_Spark
        /// <summary>
        /// <para>
        /// <para>The Spark configuration properties for SQL and PySpark workloads. This map contains
        /// key-value pairs that configure Apache Spark settings to optimize performance for your
        /// data processing jobs. You can specify up to 50 Spark properties, with each key being
        /// 1-200 characters and each value being 0-500 characters. These properties allow you
        /// to adjust compute capacity for large datasets and complex workloads.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ComputeConfiguration_QueryComputeConfiguration_Properties_Spark { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_QueryComputeConfiguration_Type
        /// <summary>
        /// <para>
        /// <para> The worker compute configuration type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRooms.WorkerComputeType")]
        public Amazon.CleanRooms.WorkerComputeType ComputeConfiguration_QueryComputeConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.PopulateIntermediateTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.PopulateIntermediateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntermediateTableIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-CRSIntermediateTable (PopulateIntermediateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.PopulateIntermediateTableResponse, ImportCRSIntermediateTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalysisPayerAccountId = this.AnalysisPayerAccountId;
            context.ComputeConfiguration_QueryComputeConfiguration_Number = this.ComputeConfiguration_QueryComputeConfiguration_Number;
            if (this.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark != null)
            {
                context.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark.Keys)
                {
                    context.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark.Add((String)hashKey, (System.String)(this.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark[hashKey]));
                }
            }
            context.ComputeConfiguration_QueryComputeConfiguration_Type = this.ComputeConfiguration_QueryComputeConfiguration_Type;
            context.IntermediateTableIdentifier = this.IntermediateTableIdentifier;
            #if MODULAR
            if (this.IntermediateTableIdentifier == null && ParameterWasBound(nameof(this.IntermediateTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IntermediateTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
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
            // create request
            var request = new Amazon.CleanRooms.Model.PopulateIntermediateTableRequest();
            
            if (cmdletContext.AnalysisPayerAccountId != null)
            {
                request.AnalysisPayerAccountId = cmdletContext.AnalysisPayerAccountId;
            }
            
             // populate ComputeConfiguration
            var requestComputeConfigurationIsNull = true;
            request.ComputeConfiguration = new Amazon.CleanRooms.Model.IntermediateTableComputeConfiguration();
            Amazon.CleanRooms.Model.WorkerComputeConfiguration requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration = null;
            
             // populate QueryComputeConfiguration
            var requestComputeConfiguration_computeConfiguration_QueryComputeConfigurationIsNull = true;
            requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration = new Amazon.CleanRooms.Model.WorkerComputeConfiguration();
            System.Int32? requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Number = null;
            if (cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Number != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Number = cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Number.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Number != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration.Number = requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Number.Value;
                requestComputeConfiguration_computeConfiguration_QueryComputeConfigurationIsNull = false;
            }
            Amazon.CleanRooms.WorkerComputeType requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Type = null;
            if (cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Type != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Type = cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Type;
            }
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Type != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration.Type = requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Type;
                requestComputeConfiguration_computeConfiguration_QueryComputeConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.WorkerComputeConfigurationProperties requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties = null;
            
             // populate Properties
            var requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_PropertiesIsNull = true;
            requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties = new Amazon.CleanRooms.Model.WorkerComputeConfigurationProperties();
            Dictionary<System.String, System.String> requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties_computeConfiguration_QueryComputeConfiguration_Properties_Spark = null;
            if (cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties_computeConfiguration_QueryComputeConfiguration_Properties_Spark = cmdletContext.ComputeConfiguration_QueryComputeConfiguration_Properties_Spark;
            }
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties_computeConfiguration_QueryComputeConfiguration_Properties_Spark != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties.Spark = requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties_computeConfiguration_QueryComputeConfiguration_Properties_Spark;
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_PropertiesIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties should be set to null
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_PropertiesIsNull)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties = null;
            }
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties != null)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration.Properties = requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration_computeConfiguration_QueryComputeConfiguration_Properties;
                requestComputeConfiguration_computeConfiguration_QueryComputeConfigurationIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration should be set to null
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfigurationIsNull)
            {
                requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration = null;
            }
            if (requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration != null)
            {
                request.ComputeConfiguration.QueryComputeConfiguration = requestComputeConfiguration_computeConfiguration_QueryComputeConfiguration;
                requestComputeConfigurationIsNull = false;
            }
             // determine if request.ComputeConfiguration should be set to null
            if (requestComputeConfigurationIsNull)
            {
                request.ComputeConfiguration = null;
            }
            if (cmdletContext.IntermediateTableIdentifier != null)
            {
                request.IntermediateTableIdentifier = cmdletContext.IntermediateTableIdentifier;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.CleanRooms.Model.PopulateIntermediateTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.PopulateIntermediateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "PopulateIntermediateTable");
            try
            {
                return client.PopulateIntermediateTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnalysisPayerAccountId { get; set; }
            public System.Int32? ComputeConfiguration_QueryComputeConfiguration_Number { get; set; }
            public Dictionary<System.String, System.String> ComputeConfiguration_QueryComputeConfiguration_Properties_Spark { get; set; }
            public Amazon.CleanRooms.WorkerComputeType ComputeConfiguration_QueryComputeConfiguration_Type { get; set; }
            public System.String IntermediateTableIdentifier { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.Func<Amazon.CleanRooms.Model.PopulateIntermediateTableResponse, ImportCRSIntermediateTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
