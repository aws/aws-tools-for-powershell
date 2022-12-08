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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Create a new workload.
    /// 
    ///  
    /// <para>
    /// The owner of a workload can share the workload with other Amazon Web Services accounts,
    /// IAM users, an organization, and organizational units (OUs) in the same Amazon Web
    /// Services Region. Only the owner of a workload can delete it.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/wellarchitected/latest/userguide/define-workload.html">Defining
    /// a Workload</a> in the <i>Well-Architected Tool User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WATWorkload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.CreateWorkloadResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool CreateWorkload API operation.", Operation = new[] {"CreateWorkload"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.CreateWorkloadResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.CreateWorkloadResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.CreateWorkloadResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWATWorkloadCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>List of AppRegistry application ARNs associated to the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public System.String[] Application { get; set; }
        #endregion
        
        #region Parameter ArchitecturalDesign
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArchitecturalDesign { get; set; }
        #endregion
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsRegions")]
        public System.String[] AwsRegion { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WellArchitected.WorkloadEnvironment")]
        public Amazon.WellArchitected.WorkloadEnvironment Environment { get; set; }
        #endregion
        
        #region Parameter Industry
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Industry { get; set; }
        #endregion
        
        #region Parameter IndustryType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndustryType { get; set; }
        #endregion
        
        #region Parameter Lense
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("Lenses")]
        public System.String[] Lense { get; set; }
        #endregion
        
        #region Parameter NonAwsRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NonAwsRegions")]
        public System.String[] NonAwsRegion { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter PillarPriority
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PillarPriorities")]
        public System.String[] PillarPriority { get; set; }
        #endregion
        
        #region Parameter ReviewOwner
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReviewOwner { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be associated with the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfig_TrustedAdvisorIntegrationStatus
        /// <summary>
        /// <para>
        /// <para>Discovery integration status in respect to Trusted Advisor for the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.TrustedAdvisorIntegrationStatus")]
        public Amazon.WellArchitected.TrustedAdvisorIntegrationStatus DiscoveryConfig_TrustedAdvisorIntegrationStatus { get; set; }
        #endregion
        
        #region Parameter WorkloadName
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
        public System.String WorkloadName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.CreateWorkloadResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.CreateWorkloadResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkloadName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WATWorkload (CreateWorkload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.CreateWorkloadResponse, NewWATWorkloadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            if (this.Application != null)
            {
                context.Application = new List<System.String>(this.Application);
            }
            context.ArchitecturalDesign = this.ArchitecturalDesign;
            if (this.AwsRegion != null)
            {
                context.AwsRegion = new List<System.String>(this.AwsRegion);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DiscoveryConfig_TrustedAdvisorIntegrationStatus = this.DiscoveryConfig_TrustedAdvisorIntegrationStatus;
            context.Environment = this.Environment;
            #if MODULAR
            if (this.Environment == null && ParameterWasBound(nameof(this.Environment)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Industry = this.Industry;
            context.IndustryType = this.IndustryType;
            if (this.Lense != null)
            {
                context.Lense = new List<System.String>(this.Lense);
            }
            #if MODULAR
            if (this.Lense == null && ParameterWasBound(nameof(this.Lense)))
            {
                WriteWarning("You are passing $null as a value for parameter Lense which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NonAwsRegion != null)
            {
                context.NonAwsRegion = new List<System.String>(this.NonAwsRegion);
            }
            context.Note = this.Note;
            if (this.PillarPriority != null)
            {
                context.PillarPriority = new List<System.String>(this.PillarPriority);
            }
            context.ReviewOwner = this.ReviewOwner;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.WorkloadName = this.WorkloadName;
            #if MODULAR
            if (this.WorkloadName == null && ParameterWasBound(nameof(this.WorkloadName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.CreateWorkloadRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.ArchitecturalDesign != null)
            {
                request.ArchitecturalDesign = cmdletContext.ArchitecturalDesign;
            }
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegions = cmdletContext.AwsRegion;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DiscoveryConfig
            var requestDiscoveryConfigIsNull = true;
            request.DiscoveryConfig = new Amazon.WellArchitected.Model.WorkloadDiscoveryConfig();
            Amazon.WellArchitected.TrustedAdvisorIntegrationStatus requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus = null;
            if (cmdletContext.DiscoveryConfig_TrustedAdvisorIntegrationStatus != null)
            {
                requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus = cmdletContext.DiscoveryConfig_TrustedAdvisorIntegrationStatus;
            }
            if (requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus != null)
            {
                request.DiscoveryConfig.TrustedAdvisorIntegrationStatus = requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus;
                requestDiscoveryConfigIsNull = false;
            }
             // determine if request.DiscoveryConfig should be set to null
            if (requestDiscoveryConfigIsNull)
            {
                request.DiscoveryConfig = null;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.Industry != null)
            {
                request.Industry = cmdletContext.Industry;
            }
            if (cmdletContext.IndustryType != null)
            {
                request.IndustryType = cmdletContext.IndustryType;
            }
            if (cmdletContext.Lense != null)
            {
                request.Lenses = cmdletContext.Lense;
            }
            if (cmdletContext.NonAwsRegion != null)
            {
                request.NonAwsRegions = cmdletContext.NonAwsRegion;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            if (cmdletContext.PillarPriority != null)
            {
                request.PillarPriorities = cmdletContext.PillarPriority;
            }
            if (cmdletContext.ReviewOwner != null)
            {
                request.ReviewOwner = cmdletContext.ReviewOwner;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkloadName != null)
            {
                request.WorkloadName = cmdletContext.WorkloadName;
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
        
        private Amazon.WellArchitected.Model.CreateWorkloadResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.CreateWorkloadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "CreateWorkload");
            try
            {
                #if DESKTOP
                return client.CreateWorkload(request);
                #elif CORECLR
                return client.CreateWorkloadAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<System.String> Application { get; set; }
            public System.String ArchitecturalDesign { get; set; }
            public List<System.String> AwsRegion { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.WellArchitected.TrustedAdvisorIntegrationStatus DiscoveryConfig_TrustedAdvisorIntegrationStatus { get; set; }
            public Amazon.WellArchitected.WorkloadEnvironment Environment { get; set; }
            public System.String Industry { get; set; }
            public System.String IndustryType { get; set; }
            public List<System.String> Lense { get; set; }
            public List<System.String> NonAwsRegion { get; set; }
            public System.String Note { get; set; }
            public List<System.String> PillarPriority { get; set; }
            public System.String ReviewOwner { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkloadName { get; set; }
            public System.Func<Amazon.WellArchitected.Model.CreateWorkloadResponse, NewWATWorkloadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
