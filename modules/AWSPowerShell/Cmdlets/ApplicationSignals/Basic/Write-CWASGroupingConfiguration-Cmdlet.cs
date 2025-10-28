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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Creates or updates a grouping configuration that defines how services are organized
    /// and grouped in Application Signals dashboards and service maps.
    /// 
    ///  
    /// <para>
    /// Grouping configurations allow you to logically organize services based on attributes
    /// such as environment, team ownership, or business function, making it easier to monitor
    /// and manage related services together.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWASGroupingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationSignals.Model.GroupingConfiguration")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals PutGroupingConfiguration API operation.", Operation = new[] {"PutGroupingConfiguration"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.GroupingConfiguration or Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.GroupingConfiguration object.",
        "The service call response (type Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWASGroupingConfigurationCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GroupingAttributeDefinition
        /// <summary>
        /// <para>
        /// <para>An array of grouping attribute definitions that specify how services should be grouped.
        /// Each definition includes the grouping name, source keys, and default values.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("GroupingAttributeDefinitions")]
        public Amazon.ApplicationSignals.Model.GroupingAttributeDefinition[] GroupingAttributeDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GroupingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GroupingConfiguration";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWASGroupingConfiguration (PutGroupingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse, WriteCWASGroupingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GroupingAttributeDefinition != null)
            {
                context.GroupingAttributeDefinition = new List<Amazon.ApplicationSignals.Model.GroupingAttributeDefinition>(this.GroupingAttributeDefinition);
            }
            #if MODULAR
            if (this.GroupingAttributeDefinition == null && ParameterWasBound(nameof(this.GroupingAttributeDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupingAttributeDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationSignals.Model.PutGroupingConfigurationRequest();
            
            if (cmdletContext.GroupingAttributeDefinition != null)
            {
                request.GroupingAttributeDefinitions = cmdletContext.GroupingAttributeDefinition;
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
        
        private Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.PutGroupingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "PutGroupingConfiguration");
            try
            {
                return client.PutGroupingConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ApplicationSignals.Model.GroupingAttributeDefinition> GroupingAttributeDefinition { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.PutGroupingConfigurationResponse, WriteCWASGroupingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GroupingConfiguration;
        }
        
    }
}
