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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Updates the specified <a>IPSet</a>. 
    /// 
    ///  <note><para>
    /// This operation completely replaces the mutable specifications that you already have
    /// for the IP set with the ones that you provide to this call. 
    /// </para><para>
    /// To modify an IP set, do the following: 
    /// </para><ol><li><para>
    /// Retrieve it by calling <a>GetIPSet</a></para></li><li><para>
    /// Update its settings as needed
    /// </para></li><li><para>
    /// Provide the complete IP set specification to this call
    /// </para></li></ol></note><para><b>Temporary inconsistencies during updates</b></para><para>
    /// When you create or change a web ACL or other WAF resources, the changes take a small
    /// amount of time to propagate to all areas where the resources are stored. The propagation
    /// time can be from a few seconds to a number of minutes. 
    /// </para><para>
    /// The following are examples of the temporary inconsistencies that you might notice
    /// during change propagation: 
    /// </para><ul><li><para>
    /// After you create a web ACL, if you try to associate it with a resource, you might
    /// get an exception indicating that the web ACL is unavailable. 
    /// </para></li><li><para>
    /// After you add a rule group to a web ACL, the new rule group rules might be in effect
    /// in one area where the web ACL is used and not in another.
    /// </para></li><li><para>
    /// After you change a rule action setting, you might see the old action in some places
    /// and the new action in others. 
    /// </para></li><li><para>
    /// After you add an IP address to an IP set that is in use in a blocking rule, the new
    /// address might be blocked in one area while still allowed in another.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "WAF2IPSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF V2 UpdateIPSet API operation.", Operation = new[] {"UpdateIPSet"}, SelectReturnType = typeof(Amazon.WAFV2.Model.UpdateIPSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFV2.Model.UpdateIPSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFV2.Model.UpdateIPSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAF2IPSetCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>Contains an array of strings that specifies zero or more IP addresses or blocks of
        /// IP addresses that you want WAF to inspect for in incoming requests. All addresses
        /// must be specified using Classless Inter-Domain Routing (CIDR) notation. WAF supports
        /// all IPv4 and IPv6 CIDR ranges except for <c>/0</c>. </para><para>Example address strings: </para><ul><li><para>For requests that originated from the IP address 192.0.2.44, specify <c>192.0.2.44/32</c>.</para></li><li><para>For requests that originated from IP addresses from 192.0.2.0 to 192.0.2.255, specify
        /// <c>192.0.2.0/24</c>.</para></li><li><para>For requests that originated from the IP address 1111:0000:0000:0000:0000:0000:0000:0111,
        /// specify <c>1111:0000:0000:0000:0000:0000:0000:0111/128</c>.</para></li><li><para>For requests that originated from IP addresses 1111:0000:0000:0000:0000:0000:0000:0000
        /// to 1111:0000:0000:0000:ffff:ffff:ffff:ffff, specify <c>1111:0000:0000:0000:0000:0000:0000:0000/64</c>.</para></li></ul><para>For more information about CIDR notation, see the Wikipedia entry <a href="https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing">Classless
        /// Inter-Domain Routing</a>.</para><para>Example JSON <c>Addresses</c> specifications: </para><ul><li><para>Empty array: <c>"Addresses": []</c></para></li><li><para>Array with one address: <c>"Addresses": ["192.0.2.44/32"]</c></para></li><li><para>Array with three addresses: <c>"Addresses": ["192.0.2.44/32", "192.0.2.0/24", "192.0.0.0/16"]</c></para></li><li><para>INVALID specification: <c>"Addresses": [""]</c> INVALID </para></li></ul>
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
        [Alias("Addresses")]
        public System.String[] Address { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the IP set that helps with identification. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the set. This ID is returned in the responses to create and
        /// list commands. You provide it to operations like update and delete.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IsAddressesSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.WAFV2.Model.UpdateIPSetRequest.Addresses" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsAddressesSet { get; set; }
        #endregion
        
        #region Parameter LockToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. WAF returns a token to your <c>get</c> and <c>list</c>
        /// requests, to mark the state of the entity at the time of the request. To make changes
        /// to the entity associated with the token, you provide the token to operations like
        /// <c>update</c> and <c>delete</c>. WAF uses the token to ensure that no changes have
        /// been made to the entity since you last retrieved it. If a change has been made, the
        /// update fails with a <c>WAFOptimisticLockException</c>. If this happens, perform another
        /// <c>get</c>, and use the new token returned by that operation. </para>
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
        public System.String LockToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the IP set. You cannot change the name of an <c>IPSet</c> after you create
        /// it.</para>
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
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for a global resource type, such as a Amazon CloudFront
        /// distribution. </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <c>--scope=CLOUDFRONT
        /// --region=us-east-1</c>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NextLockToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.UpdateIPSetResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.UpdateIPSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NextLockToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAF2IPSet (UpdateIPSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.UpdateIPSetResponse, UpdateWAF2IPSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Address != null)
            {
                context.Address = new List<System.String>(this.Address);
            }
            #if MODULAR
            if (this.Address == null && ParameterWasBound(nameof(this.Address)))
            {
                WriteWarning("You are passing $null as a value for parameter Address which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsAddressesSet = this.IsAddressesSet;
            if (!ParameterWasBound(nameof(this.IsAddressesSet)) && this.Address != null)
            {
                context.IsAddressesSet = true;
            }
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LockToken = this.LockToken;
            #if MODULAR
            if (this.LockToken == null && ParameterWasBound(nameof(this.LockToken)))
            {
                WriteWarning("You are passing $null as a value for parameter LockToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.UpdateIPSetRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Addresses = cmdletContext.Address;
            }
            if (cmdletContext.IsAddressesSet != null)
            {
                request.IsAddressesSet = cmdletContext.IsAddressesSet.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.LockToken != null)
            {
                request.LockToken = cmdletContext.LockToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
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
        
        private Amazon.WAFV2.Model.UpdateIPSetResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.UpdateIPSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "UpdateIPSet");
            try
            {
                #if DESKTOP
                return client.UpdateIPSet(request);
                #elif CORECLR
                return client.UpdateIPSetAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Address { get; set; }
            public System.Boolean? IsAddressesSet { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String LockToken { get; set; }
            public System.String Name { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.Func<Amazon.WAFV2.Model.UpdateIPSetResponse, UpdateWAF2IPSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NextLockToken;
        }
        
    }
}
