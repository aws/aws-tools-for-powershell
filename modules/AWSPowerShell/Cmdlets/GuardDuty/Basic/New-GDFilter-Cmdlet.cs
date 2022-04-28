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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Creates a filter using the specified finding criteria.
    /// </summary>
    [Cmdlet("New", "GDFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GuardDuty CreateFilter API operation.", Operation = new[] {"CreateFilter"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.CreateFilterResponse))]
    [AWSCmdletOutput("System.String or Amazon.GuardDuty.Model.CreateFilterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GuardDuty.Model.CreateFilterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGDFilterCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>Specifies the action that is to be applied to the findings that match the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.FilterAction")]
        public Amazon.GuardDuty.FilterAction Action { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the detector belonging to the GuardDuty account that you want to create
        /// a filter for.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter FindingCriterion
        /// <summary>
        /// <para>
        /// <para>Represents the criteria to be used in the filter for querying findings.</para><para>You can only use the following attributes to query findings:</para><ul><li><para>accountId</para></li><li><para>region</para></li><li><para>confidence</para></li><li><para>id</para></li><li><para>resource.accessKeyDetails.accessKeyId</para></li><li><para>resource.accessKeyDetails.principalId</para></li><li><para>resource.accessKeyDetails.userName</para></li><li><para>resource.accessKeyDetails.userType</para></li><li><para>resource.instanceDetails.iamInstanceProfile.id</para></li><li><para>resource.instanceDetails.imageId</para></li><li><para>resource.instanceDetails.instanceId</para></li><li><para>resource.instanceDetails.outpostArn</para></li><li><para>resource.instanceDetails.networkInterfaces.ipv6Addresses</para></li><li><para>resource.instanceDetails.networkInterfaces.privateIpAddresses.privateIpAddress</para></li><li><para>resource.instanceDetails.networkInterfaces.publicDnsName</para></li><li><para>resource.instanceDetails.networkInterfaces.publicIp</para></li><li><para>resource.instanceDetails.networkInterfaces.securityGroups.groupId</para></li><li><para>resource.instanceDetails.networkInterfaces.securityGroups.groupName</para></li><li><para>resource.instanceDetails.networkInterfaces.subnetId</para></li><li><para>resource.instanceDetails.networkInterfaces.vpcId</para></li><li><para>resource.instanceDetails.tags.key</para></li><li><para>resource.instanceDetails.tags.value</para></li><li><para>resource.resourceType</para></li><li><para>service.action.actionType</para></li><li><para>service.action.awsApiCallAction.api</para></li><li><para>service.action.awsApiCallAction.callerType</para></li><li><para>service.action.awsApiCallAction.errorCode</para></li><li><para>service.action.awsApiCallAction.userAgent</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.awsApiCallAction.serviceName</para></li><li><para>service.action.dnsRequestAction.domain</para></li><li><para>service.action.networkConnectionAction.blocked</para></li><li><para>service.action.networkConnectionAction.connectionDirection</para></li><li><para>service.action.networkConnectionAction.localPortDetails.port</para></li><li><para>service.action.networkConnectionAction.protocol</para></li><li><para>service.action.networkConnectionAction.localIpDetails.ipAddressV4</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.networkConnectionAction.remotePortDetails.port</para></li><li><para>service.additionalInfo.threatListName</para></li><li><para>resource.s3BucketDetails.publicAccess.effectivePermissions</para></li><li><para>resource.s3BucketDetails.name</para></li><li><para>resource.s3BucketDetails.tags.key</para></li><li><para>resource.s3BucketDetails.tags.value</para></li><li><para>resource.s3BucketDetails.type</para></li><li><para>service.archived</para><para>When this attribute is set to TRUE, only archived findings are listed. When it's set
        /// to FALSE, only unarchived findings are listed. When this attribute is not set, all
        /// existing findings are listed.</para></li><li><para>service.resourceRole</para></li><li><para>severity</para></li><li><para>type</para></li><li><para>updatedAt</para><para>Type: ISO 8601 string format: YYYY-MM-DDTHH:MM:SS.SSSZ or YYYY-MM-DDTHH:MM:SSZ depending
        /// on whether the value contains milliseconds.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FindingCriteria")]
        public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the filter. Minimum length of 3. Maximum length of 64. Valid characters
        /// include alphanumeric characters, dot (.), underscore (_), and dash (-). Spaces are
        /// not allowed.</para>
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
        
        #region Parameter Rank
        /// <summary>
        /// <para>
        /// <para>Specifies the position of the filter in the list of current filters. Also specifies
        /// the order in which this filter is applied to the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Rank { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be added to a new filter resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the create request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.CreateFilterResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.CreateFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DetectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDFilter (CreateFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.CreateFilterResponse, NewGDFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DetectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action = this.Action;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FindingCriterion = this.FindingCriterion;
            #if MODULAR
            if (this.FindingCriterion == null && ParameterWasBound(nameof(this.FindingCriterion)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingCriterion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rank = this.Rank;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.GuardDuty.Model.CreateFilterRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.FindingCriterion != null)
            {
                request.FindingCriteria = cmdletContext.FindingCriterion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Rank != null)
            {
                request.Rank = cmdletContext.Rank.Value;
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
        
        private Amazon.GuardDuty.Model.CreateFilterResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.CreateFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "CreateFilter");
            try
            {
                #if DESKTOP
                return client.CreateFilter(request);
                #elif CORECLR
                return client.CreateFilterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GuardDuty.FilterAction Action { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DetectorId { get; set; }
            public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Rank { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GuardDuty.Model.CreateFilterResponse, NewGDFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
