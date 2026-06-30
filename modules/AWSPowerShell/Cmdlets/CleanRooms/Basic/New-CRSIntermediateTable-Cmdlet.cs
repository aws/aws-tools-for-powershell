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
    /// Creates an intermediate table in a membership. An intermediate table stores a query
    /// definition that you can execute later using <c>PopulateIntermediateTable</c> to materialize
    /// cached results. The intermediate table is owned by the member with the CAN_QUERY ability.
    /// This operation does not execute the stored query.
    /// </summary>
    [Cmdlet("New", "CRSIntermediateTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.IntermediateTable")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateIntermediateTable API operation.", Operation = new[] {"CreateIntermediateTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateIntermediateTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.IntermediateTable or Amazon.CleanRooms.Model.CreateIntermediateTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.IntermediateTable object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateIntermediateTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSIntermediateTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the analysis template to use for populating the
        /// intermediate table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the intermediate table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer-managed KMS key used to encrypt the
        /// intermediate table data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership where the intermediate table is created.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for the intermediate table.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PopulationAnalysisConfiguration_SqlParameters_QueryString
        /// <summary>
        /// <para>
        /// <para>The SQL query string used to populate the intermediate table. Maximum length of 500,000
        /// characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PopulationAnalysisConfiguration_SqlParameters_QueryString { get; set; }
        #endregion
        
        #region Parameter RetentionInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain populated data versions. Minimum value of 1, maximum
        /// value of 365.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionInDays")]
        public System.Int32? RetentionInDay { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IntermediateTable'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateIntermediateTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateIntermediateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IntermediateTable";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.MembershipIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSIntermediateTable (CreateIntermediateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateIntermediateTableResponse, NewCRSIntermediateTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.KmsKeyArn = this.KmsKeyArn;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn = this.PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn;
            context.PopulationAnalysisConfiguration_SqlParameters_QueryString = this.PopulationAnalysisConfiguration_SqlParameters_QueryString;
            context.RetentionInDay = this.RetentionInDay;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.CleanRooms.Model.CreateIntermediateTableRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PopulationAnalysisConfiguration
            var requestPopulationAnalysisConfigurationIsNull = true;
            request.PopulationAnalysisConfiguration = new Amazon.CleanRooms.Model.PopulationAnalysisConfiguration();
            Amazon.CleanRooms.Model.PopulationAnalysisSqlParameters requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters = null;
            
             // populate SqlParameters
            var requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParametersIsNull = true;
            requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters = new Amazon.CleanRooms.Model.PopulationAnalysisSqlParameters();
            System.String requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn = null;
            if (cmdletContext.PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn != null)
            {
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn = cmdletContext.PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn;
            }
            if (requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn != null)
            {
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters.AnalysisTemplateArn = requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn;
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParametersIsNull = false;
            }
            System.String requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_QueryString = null;
            if (cmdletContext.PopulationAnalysisConfiguration_SqlParameters_QueryString != null)
            {
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_QueryString = cmdletContext.PopulationAnalysisConfiguration_SqlParameters_QueryString;
            }
            if (requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_QueryString != null)
            {
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters.QueryString = requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters_populationAnalysisConfiguration_SqlParameters_QueryString;
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParametersIsNull = false;
            }
             // determine if requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters should be set to null
            if (requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParametersIsNull)
            {
                requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters = null;
            }
            if (requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters != null)
            {
                request.PopulationAnalysisConfiguration.SqlParameters = requestPopulationAnalysisConfiguration_populationAnalysisConfiguration_SqlParameters;
                requestPopulationAnalysisConfigurationIsNull = false;
            }
             // determine if request.PopulationAnalysisConfiguration should be set to null
            if (requestPopulationAnalysisConfigurationIsNull)
            {
                request.PopulationAnalysisConfiguration = null;
            }
            if (cmdletContext.RetentionInDay != null)
            {
                request.RetentionInDays = cmdletContext.RetentionInDay.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CleanRooms.Model.CreateIntermediateTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateIntermediateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateIntermediateTable");
            try
            {
                return client.CreateIntermediateTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String PopulationAnalysisConfiguration_SqlParameters_AnalysisTemplateArn { get; set; }
            public System.String PopulationAnalysisConfiguration_SqlParameters_QueryString { get; set; }
            public System.Int32? RetentionInDay { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateIntermediateTableResponse, NewCRSIntermediateTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IntermediateTable;
        }
        
    }
}
