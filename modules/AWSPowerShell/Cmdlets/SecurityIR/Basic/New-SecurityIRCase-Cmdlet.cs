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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Grants permission to create a new case.
    /// </summary>
    [Cmdlet("New", "SecurityIRCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Security Incident Response CreateCase API operation.", Operation = new[] {"CreateCase"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.CreateCaseResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityIR.Model.CreateCaseResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityIR.Model.CreateCaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSecurityIRCaseCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide a description for
        /// the new case.</para>
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
        
        #region Parameter EngagementType
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide an engagement type
        /// for the new cases. Available engagement types include Security Incident | Investigation
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityIR.EngagementType")]
        public Amazon.SecurityIR.EngagementType EngagementType { get; set; }
        #endregion
        
        #region Parameter ImpactedAccount
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide a list of impacted
        /// accounts.</para>
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
        [Alias("ImpactedAccounts")]
        public System.String[] ImpactedAccount { get; set; }
        #endregion
        
        #region Parameter ImpactedAwsRegion
        /// <summary>
        /// <para>
        /// <para>An optional element used in combination with CreateCase to provide a list of impacted
        /// regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImpactedAwsRegions")]
        public Amazon.SecurityIR.Model.ImpactedAwsRegion[] ImpactedAwsRegion { get; set; }
        #endregion
        
        #region Parameter ImpactedService
        /// <summary>
        /// <para>
        /// <para>An optional element used in combination with CreateCase to provide a list of services
        /// impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImpactedServices")]
        public System.String[] ImpactedService { get; set; }
        #endregion
        
        #region Parameter ReportedIncidentStartDate
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide an initial start date
        /// for the unauthorized activity. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ReportedIncidentStartDate { get; set; }
        #endregion
        
        #region Parameter ResolverType
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to identify the resolver type.
        /// Available resolvers include self-supported | aws-supported. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityIR.ResolverType")]
        public Amazon.SecurityIR.ResolverType ResolverType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional element used in combination with CreateCase to add customer specified
        /// tags to a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ThreatActorIpAddress
        /// <summary>
        /// <para>
        /// <para>An optional element used in combination with CreateCase to provide a list of suspicious
        /// internet protocol addresses associated with unauthorized activity. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThreatActorIpAddresses")]
        public Amazon.SecurityIR.Model.ThreatActorIp[] ThreatActorIpAddress { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide a title for the new
        /// case.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Watcher
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase to provide a list of entities
        /// to receive notifications for case updates. </para>
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
        [Alias("Watchers")]
        public Amazon.SecurityIR.Model.Watcher[] Watcher { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateCase.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CaseId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.CreateCaseResponse).
        /// Specifying the name of a property of type Amazon.SecurityIR.Model.CreateCaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CaseId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Title parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SecurityIRCase (CreateCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.CreateCaseResponse, NewSecurityIRCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Title;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngagementType = this.EngagementType;
            #if MODULAR
            if (this.EngagementType == null && ParameterWasBound(nameof(this.EngagementType)))
            {
                WriteWarning("You are passing $null as a value for parameter EngagementType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ImpactedAccount != null)
            {
                context.ImpactedAccount = new List<System.String>(this.ImpactedAccount);
            }
            #if MODULAR
            if (this.ImpactedAccount == null && ParameterWasBound(nameof(this.ImpactedAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter ImpactedAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ImpactedAwsRegion != null)
            {
                context.ImpactedAwsRegion = new List<Amazon.SecurityIR.Model.ImpactedAwsRegion>(this.ImpactedAwsRegion);
            }
            if (this.ImpactedService != null)
            {
                context.ImpactedService = new List<System.String>(this.ImpactedService);
            }
            context.ReportedIncidentStartDate = this.ReportedIncidentStartDate;
            #if MODULAR
            if (this.ReportedIncidentStartDate == null && ParameterWasBound(nameof(this.ReportedIncidentStartDate)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportedIncidentStartDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolverType = this.ResolverType;
            #if MODULAR
            if (this.ResolverType == null && ParameterWasBound(nameof(this.ResolverType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolverType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.ThreatActorIpAddress != null)
            {
                context.ThreatActorIpAddress = new List<Amazon.SecurityIR.Model.ThreatActorIp>(this.ThreatActorIpAddress);
            }
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Watcher != null)
            {
                context.Watcher = new List<Amazon.SecurityIR.Model.Watcher>(this.Watcher);
            }
            #if MODULAR
            if (this.Watcher == null && ParameterWasBound(nameof(this.Watcher)))
            {
                WriteWarning("You are passing $null as a value for parameter Watcher which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityIR.Model.CreateCaseRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EngagementType != null)
            {
                request.EngagementType = cmdletContext.EngagementType;
            }
            if (cmdletContext.ImpactedAccount != null)
            {
                request.ImpactedAccounts = cmdletContext.ImpactedAccount;
            }
            if (cmdletContext.ImpactedAwsRegion != null)
            {
                request.ImpactedAwsRegions = cmdletContext.ImpactedAwsRegion;
            }
            if (cmdletContext.ImpactedService != null)
            {
                request.ImpactedServices = cmdletContext.ImpactedService;
            }
            if (cmdletContext.ReportedIncidentStartDate != null)
            {
                request.ReportedIncidentStartDate = cmdletContext.ReportedIncidentStartDate.Value;
            }
            if (cmdletContext.ResolverType != null)
            {
                request.ResolverType = cmdletContext.ResolverType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThreatActorIpAddress != null)
            {
                request.ThreatActorIpAddresses = cmdletContext.ThreatActorIpAddress;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.Watcher != null)
            {
                request.Watchers = cmdletContext.Watcher;
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
        
        private Amazon.SecurityIR.Model.CreateCaseResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.CreateCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "CreateCase");
            try
            {
                #if DESKTOP
                return client.CreateCase(request);
                #elif CORECLR
                return client.CreateCaseAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.SecurityIR.EngagementType EngagementType { get; set; }
            public List<System.String> ImpactedAccount { get; set; }
            public List<Amazon.SecurityIR.Model.ImpactedAwsRegion> ImpactedAwsRegion { get; set; }
            public List<System.String> ImpactedService { get; set; }
            public System.DateTime? ReportedIncidentStartDate { get; set; }
            public Amazon.SecurityIR.ResolverType ResolverType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.SecurityIR.Model.ThreatActorIp> ThreatActorIpAddress { get; set; }
            public System.String Title { get; set; }
            public List<Amazon.SecurityIR.Model.Watcher> Watcher { get; set; }
            public System.Func<Amazon.SecurityIR.Model.CreateCaseResponse, NewSecurityIRCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CaseId;
        }
        
    }
}
