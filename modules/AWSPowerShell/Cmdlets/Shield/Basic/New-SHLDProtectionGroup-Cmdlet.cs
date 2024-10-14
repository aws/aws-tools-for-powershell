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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Creates a grouping of protected resources so they can be handled as a collective.
    /// This resource grouping improves the accuracy of detection and reduces false positives.
    /// </summary>
    [Cmdlet("New", "SHLDProtectionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield CreateProtectionGroup API operation.", Operation = new[] {"CreateProtectionGroup"}, SelectReturnType = typeof(Amazon.Shield.Model.CreateProtectionGroupResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.CreateProtectionGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.CreateProtectionGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSHLDProtectionGroupCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Aggregation
        /// <summary>
        /// <para>
        /// <para>Defines how Shield combines resource data for the group in order to detect, mitigate,
        /// and report events.</para><ul><li><para>Sum - Use the total traffic across the group. This is a good choice for most cases.
        /// Examples include Elastic IP addresses for EC2 instances that scale manually or automatically.</para></li><li><para>Mean - Use the average of the traffic across the group. This is a good choice for
        /// resources that share traffic uniformly. Examples include accelerators and load balancers.</para></li><li><para>Max - Use the highest traffic from each resource. This is useful for resources that
        /// don't share traffic and for resources that share that traffic in a non-uniform way.
        /// Examples include Amazon CloudFront and origin resources for CloudFront distributions.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Shield.ProtectionGroupAggregation")]
        public Amazon.Shield.ProtectionGroupAggregation Aggregation { get; set; }
        #endregion
        
        #region Parameter Member
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the resources to include in the protection group.
        /// You must set this when you set <c>Pattern</c> to <c>ARBITRARY</c> and you must not
        /// set it for any other <c>Pattern</c> setting. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Members")]
        public System.String[] Member { get; set; }
        #endregion
        
        #region Parameter Pattern
        /// <summary>
        /// <para>
        /// <para>The criteria to use to choose the protected resources for inclusion in the group.
        /// You can include all resources that have protections, provide a list of resource Amazon
        /// Resource Names (ARNs), or include all resources of a specified resource type. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Shield.ProtectionGroupPattern")]
        public Amazon.Shield.ProtectionGroupPattern Pattern { get; set; }
        #endregion
        
        #region Parameter ProtectionGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the protection group. You use this to identify the protection group in
        /// lists and to manage the protection group, for example to update, delete, or describe
        /// it. </para>
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
        public System.String ProtectionGroupId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type to include in the protection group. All protected resources of this
        /// type are included in the protection group. Newly protected resources of this type
        /// are automatically added to the group. You must set this when you set <c>Pattern</c>
        /// to <c>BY_RESOURCE_TYPE</c> and you must not set it for any other <c>Pattern</c> setting.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Shield.ProtectedResourceType")]
        public Amazon.Shield.ProtectedResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tag key-value pairs for the protection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Shield.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.CreateProtectionGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProtectionGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProtectionGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProtectionGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProtectionGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHLDProtectionGroup (CreateProtectionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.CreateProtectionGroupResponse, NewSHLDProtectionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProtectionGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Aggregation = this.Aggregation;
            #if MODULAR
            if (this.Aggregation == null && ParameterWasBound(nameof(this.Aggregation)))
            {
                WriteWarning("You are passing $null as a value for parameter Aggregation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Member != null)
            {
                context.Member = new List<System.String>(this.Member);
            }
            context.Pattern = this.Pattern;
            #if MODULAR
            if (this.Pattern == null && ParameterWasBound(nameof(this.Pattern)))
            {
                WriteWarning("You are passing $null as a value for parameter Pattern which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtectionGroupId = this.ProtectionGroupId;
            #if MODULAR
            if (this.ProtectionGroupId == null && ParameterWasBound(nameof(this.ProtectionGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtectionGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Shield.Model.Tag>(this.Tag);
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
            var request = new Amazon.Shield.Model.CreateProtectionGroupRequest();
            
            if (cmdletContext.Aggregation != null)
            {
                request.Aggregation = cmdletContext.Aggregation;
            }
            if (cmdletContext.Member != null)
            {
                request.Members = cmdletContext.Member;
            }
            if (cmdletContext.Pattern != null)
            {
                request.Pattern = cmdletContext.Pattern;
            }
            if (cmdletContext.ProtectionGroupId != null)
            {
                request.ProtectionGroupId = cmdletContext.ProtectionGroupId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.Shield.Model.CreateProtectionGroupResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.CreateProtectionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "CreateProtectionGroup");
            try
            {
                #if DESKTOP
                return client.CreateProtectionGroup(request);
                #elif CORECLR
                return client.CreateProtectionGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Shield.ProtectionGroupAggregation Aggregation { get; set; }
            public List<System.String> Member { get; set; }
            public Amazon.Shield.ProtectionGroupPattern Pattern { get; set; }
            public System.String ProtectionGroupId { get; set; }
            public Amazon.Shield.ProtectedResourceType ResourceType { get; set; }
            public List<Amazon.Shield.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Shield.Model.CreateProtectionGroupResponse, NewSHLDProtectionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
