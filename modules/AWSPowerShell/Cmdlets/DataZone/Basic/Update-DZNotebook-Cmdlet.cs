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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates a <a href="https://docs.aws.amazon.com/sagemaker-unified-studio/latest/userguide/notebooks.html">notebook</a>
    /// in Amazon SageMaker Unified Studio.
    /// </summary>
    [Cmdlet("Update", "DZNotebook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateNotebookResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateNotebook API operation.", Operation = new[] {"UpdateNotebook"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateNotebookResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateNotebookResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateNotebookResponse object containing multiple properties."
    )]
    public partial class UpdateDZNotebookCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CellOrder
        /// <summary>
        /// <para>
        /// <para>The updated ordered list of cells in the notebook.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.CellInformation[] CellOrder { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the notebook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon SageMaker Unified Studio domain in which the notebook
        /// exists.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the notebook to update.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentConfiguration_ImageVersion
        /// <summary>
        /// <para>
        /// <para>The image version for the notebook run environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentConfiguration_ImageVersion { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The updated metadata for the notebook, specified as key-value pairs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the notebook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EnvironmentConfiguration_PackageConfig_PackageManager
        /// <summary>
        /// <para>
        /// <para>The package manager for the notebook run environment. The default value is <c>UV</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.PackageManager")]
        public Amazon.DataZone.PackageManager EnvironmentConfiguration_PackageConfig_PackageManager { get; set; }
        #endregion
        
        #region Parameter EnvironmentConfiguration_PackageConfig_PackageSpecification
        /// <summary>
        /// <para>
        /// <para>The package specification content for the notebook run environment. The maximum length
        /// is 10240 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentConfiguration_PackageConfig_PackageSpecification { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The updated sensitive parameters for the notebook, specified as key-value pairs.</para><para />
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
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The updated status of the notebook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.NotebookStatus")]
        public Amazon.DataZone.NotebookStatus Status { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This field
        /// is automatically populated if not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateNotebookResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateNotebookResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainIdentifier),
                nameof(this.Identifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZNotebook (UpdateNotebook)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateNotebookResponse, UpdateDZNotebookCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CellOrder != null)
            {
                context.CellOrder = new List<Amazon.DataZone.Model.CellInformation>(this.CellOrder);
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentConfiguration_ImageVersion = this.EnvironmentConfiguration_ImageVersion;
            context.EnvironmentConfiguration_PackageConfig_PackageManager = this.EnvironmentConfiguration_PackageConfig_PackageManager;
            context.EnvironmentConfiguration_PackageConfig_PackageSpecification = this.EnvironmentConfiguration_PackageConfig_PackageSpecification;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.Name = this.Name;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            context.Status = this.Status;
            
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
            var request = new Amazon.DataZone.Model.UpdateNotebookRequest();
            
            if (cmdletContext.CellOrder != null)
            {
                request.CellOrder = cmdletContext.CellOrder;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            
             // populate EnvironmentConfiguration
            var requestEnvironmentConfigurationIsNull = true;
            request.EnvironmentConfiguration = new Amazon.DataZone.Model.EnvironmentConfig();
            System.String requestEnvironmentConfiguration_environmentConfiguration_ImageVersion = null;
            if (cmdletContext.EnvironmentConfiguration_ImageVersion != null)
            {
                requestEnvironmentConfiguration_environmentConfiguration_ImageVersion = cmdletContext.EnvironmentConfiguration_ImageVersion;
            }
            if (requestEnvironmentConfiguration_environmentConfiguration_ImageVersion != null)
            {
                request.EnvironmentConfiguration.ImageVersion = requestEnvironmentConfiguration_environmentConfiguration_ImageVersion;
                requestEnvironmentConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.PackageConfig requestEnvironmentConfiguration_environmentConfiguration_PackageConfig = null;
            
             // populate PackageConfig
            var requestEnvironmentConfiguration_environmentConfiguration_PackageConfigIsNull = true;
            requestEnvironmentConfiguration_environmentConfiguration_PackageConfig = new Amazon.DataZone.Model.PackageConfig();
            Amazon.DataZone.PackageManager requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageManager = null;
            if (cmdletContext.EnvironmentConfiguration_PackageConfig_PackageManager != null)
            {
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageManager = cmdletContext.EnvironmentConfiguration_PackageConfig_PackageManager;
            }
            if (requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageManager != null)
            {
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfig.PackageManager = requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageManager;
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfigIsNull = false;
            }
            System.String requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageSpecification = null;
            if (cmdletContext.EnvironmentConfiguration_PackageConfig_PackageSpecification != null)
            {
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageSpecification = cmdletContext.EnvironmentConfiguration_PackageConfig_PackageSpecification;
            }
            if (requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageSpecification != null)
            {
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfig.PackageSpecification = requestEnvironmentConfiguration_environmentConfiguration_PackageConfig_environmentConfiguration_PackageConfig_PackageSpecification;
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfigIsNull = false;
            }
             // determine if requestEnvironmentConfiguration_environmentConfiguration_PackageConfig should be set to null
            if (requestEnvironmentConfiguration_environmentConfiguration_PackageConfigIsNull)
            {
                requestEnvironmentConfiguration_environmentConfiguration_PackageConfig = null;
            }
            if (requestEnvironmentConfiguration_environmentConfiguration_PackageConfig != null)
            {
                request.EnvironmentConfiguration.PackageConfig = requestEnvironmentConfiguration_environmentConfiguration_PackageConfig;
                requestEnvironmentConfigurationIsNull = false;
            }
             // determine if request.EnvironmentConfiguration should be set to null
            if (requestEnvironmentConfigurationIsNull)
            {
                request.EnvironmentConfiguration = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.DataZone.Model.UpdateNotebookResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateNotebookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateNotebook");
            try
            {
                return client.UpdateNotebookAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.DataZone.Model.CellInformation> CellOrder { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EnvironmentConfiguration_ImageVersion { get; set; }
            public Amazon.DataZone.PackageManager EnvironmentConfiguration_PackageConfig_PackageManager { get; set; }
            public System.String EnvironmentConfiguration_PackageConfig_PackageSpecification { get; set; }
            public System.String Identifier { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public Amazon.DataZone.NotebookStatus Status { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateNotebookResponse, UpdateDZNotebookCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
