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
using Amazon.Resiliencehubv2;
using Amazon.Resiliencehubv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RH2
{
    /// <summary>
    /// Creates a service.
    /// </summary>
    [Cmdlet("New", "RH2Service", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Resiliencehubv2.Model.Service")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 CreateService API operation.", Operation = new[] {"CreateService"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.CreateServiceResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.Service or Amazon.Resiliencehubv2.Model.CreateServiceResponse",
        "This cmdlet returns an Amazon.Resiliencehubv2.Model.Service object.",
        "The service call response (type Amazon.Resiliencehubv2.Model.CreateServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRH2ServiceCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedSystem
        /// <summary>
        /// <para>
        /// <para>The systems to associate with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedSystems")]
        public Amazon.Resiliencehubv2.Model.AssociatedSystem[] AssociatedSystem { get; set; }
        #endregion
        
        #region Parameter PermissionModel_CrossAccountRole
        /// <summary>
        /// <para>
        /// <para>The list of cross-account IAM role ARNs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionModel_CrossAccountRoles")]
        public Amazon.Resiliencehubv2.Model.CrossAccountRole[] PermissionModel_CrossAccountRole { get; set; }
        #endregion
        
        #region Parameter DependencyDiscovery
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Resiliencehubv2.DependencyDiscoveryInput")]
        public Amazon.Resiliencehubv2.DependencyDiscoveryInput DependencyDiscovery { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PermissionModel_InvokerRoleName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String PermissionModel_InvokerRoleName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter Regions
        /// <summary>
        /// <para>
        /// <para>The AWS Regions where the service operates.</para><para />
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
        public System.String[] Regions { get; set; }
        #endregion
        
        #region Parameter ReportConfiguration_ReportOutput
        /// <summary>
        /// <para>
        /// <para>Output destinations for generated reports.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportConfiguration_ReportOutputs")]
        public Amazon.Resiliencehubv2.Model.ReportOutputConfiguration[] ReportConfiguration_ReportOutput { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.CreateServiceResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.CreateServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Service";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RH2Service (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.CreateServiceResponse, NewRH2ServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedSystem != null)
            {
                context.AssociatedSystem = new List<Amazon.Resiliencehubv2.Model.AssociatedSystem>(this.AssociatedSystem);
            }
            context.ClientToken = this.ClientToken;
            context.DependencyDiscovery = this.DependencyDiscovery;
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PermissionModel_CrossAccountRole != null)
            {
                context.PermissionModel_CrossAccountRole = new List<Amazon.Resiliencehubv2.Model.CrossAccountRole>(this.PermissionModel_CrossAccountRole);
            }
            context.PermissionModel_InvokerRoleName = this.PermissionModel_InvokerRoleName;
            #if MODULAR
            if (this.PermissionModel_InvokerRoleName == null && ParameterWasBound(nameof(this.PermissionModel_InvokerRoleName)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionModel_InvokerRoleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyArn = this.PolicyArn;
            if (this.Regions != null)
            {
                context.Regions = new List<System.String>(this.Regions);
            }
            #if MODULAR
            if (this.Regions == null && ParameterWasBound(nameof(this.Regions)))
            {
                WriteWarning("You are passing $null as a value for parameter Regions which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReportConfiguration_ReportOutput != null)
            {
                context.ReportConfiguration_ReportOutput = new List<Amazon.Resiliencehubv2.Model.ReportOutputConfiguration>(this.ReportConfiguration_ReportOutput);
            }
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
            var request = new Amazon.Resiliencehubv2.Model.CreateServiceRequest();
            
            if (cmdletContext.AssociatedSystem != null)
            {
                request.AssociatedSystems = cmdletContext.AssociatedSystem;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DependencyDiscovery != null)
            {
                request.DependencyDiscovery = cmdletContext.DependencyDiscovery;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PermissionModel
            var requestPermissionModelIsNull = true;
            request.PermissionModel = new Amazon.Resiliencehubv2.Model.PermissionModel();
            List<Amazon.Resiliencehubv2.Model.CrossAccountRole> requestPermissionModel_permissionModel_CrossAccountRole = null;
            if (cmdletContext.PermissionModel_CrossAccountRole != null)
            {
                requestPermissionModel_permissionModel_CrossAccountRole = cmdletContext.PermissionModel_CrossAccountRole;
            }
            if (requestPermissionModel_permissionModel_CrossAccountRole != null)
            {
                request.PermissionModel.CrossAccountRoles = requestPermissionModel_permissionModel_CrossAccountRole;
                requestPermissionModelIsNull = false;
            }
            System.String requestPermissionModel_permissionModel_InvokerRoleName = null;
            if (cmdletContext.PermissionModel_InvokerRoleName != null)
            {
                requestPermissionModel_permissionModel_InvokerRoleName = cmdletContext.PermissionModel_InvokerRoleName;
            }
            if (requestPermissionModel_permissionModel_InvokerRoleName != null)
            {
                request.PermissionModel.InvokerRoleName = requestPermissionModel_permissionModel_InvokerRoleName;
                requestPermissionModelIsNull = false;
            }
             // determine if request.PermissionModel should be set to null
            if (requestPermissionModelIsNull)
            {
                request.PermissionModel = null;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.Regions != null)
            {
                request.Regions = cmdletContext.Regions;
            }
            
             // populate ReportConfiguration
            var requestReportConfigurationIsNull = true;
            request.ReportConfiguration = new Amazon.Resiliencehubv2.Model.ServiceReportConfiguration();
            List<Amazon.Resiliencehubv2.Model.ReportOutputConfiguration> requestReportConfiguration_reportConfiguration_ReportOutput = null;
            if (cmdletContext.ReportConfiguration_ReportOutput != null)
            {
                requestReportConfiguration_reportConfiguration_ReportOutput = cmdletContext.ReportConfiguration_ReportOutput;
            }
            if (requestReportConfiguration_reportConfiguration_ReportOutput != null)
            {
                request.ReportConfiguration.ReportOutputs = requestReportConfiguration_reportConfiguration_ReportOutput;
                requestReportConfigurationIsNull = false;
            }
             // determine if request.ReportConfiguration should be set to null
            if (requestReportConfigurationIsNull)
            {
                request.ReportConfiguration = null;
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
        
        private Amazon.Resiliencehubv2.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "CreateService");
            try
            {
                return client.CreateServiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Resiliencehubv2.Model.AssociatedSystem> AssociatedSystem { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.Resiliencehubv2.DependencyDiscoveryInput DependencyDiscovery { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Resiliencehubv2.Model.CrossAccountRole> PermissionModel_CrossAccountRole { get; set; }
            public System.String PermissionModel_InvokerRoleName { get; set; }
            public System.String PolicyArn { get; set; }
            public List<System.String> Regions { get; set; }
            public List<Amazon.Resiliencehubv2.Model.ReportOutputConfiguration> ReportConfiguration_ReportOutput { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Resiliencehubv2.Model.CreateServiceResponse, NewRH2ServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
