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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Runs an AWS Lambda job that does the following:
    /// 
    ///  <ol><li><para>
    /// All the profileKeys in the <code>ProfileToBeMerged</code> will be moved to the main
    /// profile.
    /// </para></li><li><para>
    /// All the objects in the <code>ProfileToBeMerged</code> will be moved to the main profile.
    /// </para></li><li><para>
    /// All the <code>ProfileToBeMerged</code> will be deleted at the end.
    /// </para></li><li><para>
    /// All the profileKeys in the <code>ProfileIdsToBeMerged</code> will be moved to the
    /// main profile.
    /// </para></li><li><para>
    /// Standard fields are merged as follows:
    /// </para><ol><li><para>
    /// Fields are always "union"-ed if there are no conflicts in standard fields or attributeKeys.
    /// </para></li><li><para>
    /// When there are conflicting fields:
    /// </para><ol><li><para>
    /// If no <code>SourceProfileIds</code> entry is specified, the main Profile value is
    /// always taken. 
    /// </para></li><li><para>
    /// If a <code>SourceProfileIds</code> entry is specified, the specified profileId is
    /// always taken, even if it is a NULL value.
    /// </para></li></ol></li></ol></li></ol><para>
    /// You can use MergeProfiles together with <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_GetMatches.html">GetMatches</a>,
    /// which returns potentially matching profiles, or use it with the results of another
    /// matching system. After profiles have been merged, they cannot be separated (unmerged).
    /// </para>
    /// </summary>
    [Cmdlet("Merge", "CPFProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles MergeProfiles API operation.", Operation = new[] {"MergeProfiles"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.MergeProfilesResponse))]
    [AWSCmdletOutput("System.String or Amazon.CustomerProfiles.Model.MergeProfilesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CustomerProfiles.Model.MergeProfilesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class MergeCPFProfileCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        #region Parameter FieldSourceProfileIds_AccountNumber
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the account number field to be merged. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_AccountNumber { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_AdditionalInformation
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the additional information field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_AdditionalInformation { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_Address
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the party type field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_Address { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_Attribute
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the attributes field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldSourceProfileIds_Attributes")]
        public System.Collections.Hashtable FieldSourceProfileIds_Attribute { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_BillingAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the billing type field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_BillingAddress { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_BirthDate
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the birthdate field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_BirthDate { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_BusinessEmailAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the party type field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_BusinessEmailAddress { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_BusinessName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the business name field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_BusinessName { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_BusinessPhoneNumber
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the business phone number field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_BusinessPhoneNumber { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_EmailAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the email address field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_EmailAddress { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_FirstName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the first name field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_FirstName { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_Gender
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the gender field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_Gender { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_HomePhoneNumber
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the home phone number field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_HomePhoneNumber { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_LastName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the last name field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_LastName { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_MailingAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the mailing address field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_MailingAddress { get; set; }
        #endregion
        
        #region Parameter MainProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the profile to be taken.</para>
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
        public System.String MainProfileId { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_MiddleName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the middle name field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_MiddleName { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_MobilePhoneNumber
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the mobile phone number field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_MobilePhoneNumber { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_PartyType
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the party type field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_PartyType { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_PersonalEmailAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the personal email address field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_PersonalEmailAddress { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the phone number field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter ProfileIdsToBeMerged
        /// <summary>
        /// <para>
        /// <para>The identifier of the profile to be merged into MainProfileId.</para>
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
        public System.String[] ProfileIdsToBeMerged { get; set; }
        #endregion
        
        #region Parameter FieldSourceProfileIds_ShippingAddress
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the shipping address field to be merged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldSourceProfileIds_ShippingAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Message'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.MergeProfilesResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.MergeProfilesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Message";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MainProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Merge-CPFProfile (MergeProfiles)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.MergeProfilesResponse, MergeCPFProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FieldSourceProfileIds_AccountNumber = this.FieldSourceProfileIds_AccountNumber;
            context.FieldSourceProfileIds_AdditionalInformation = this.FieldSourceProfileIds_AdditionalInformation;
            context.FieldSourceProfileIds_Address = this.FieldSourceProfileIds_Address;
            if (this.FieldSourceProfileIds_Attribute != null)
            {
                context.FieldSourceProfileIds_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FieldSourceProfileIds_Attribute.Keys)
                {
                    context.FieldSourceProfileIds_Attribute.Add((String)hashKey, (String)(this.FieldSourceProfileIds_Attribute[hashKey]));
                }
            }
            context.FieldSourceProfileIds_BillingAddress = this.FieldSourceProfileIds_BillingAddress;
            context.FieldSourceProfileIds_BirthDate = this.FieldSourceProfileIds_BirthDate;
            context.FieldSourceProfileIds_BusinessEmailAddress = this.FieldSourceProfileIds_BusinessEmailAddress;
            context.FieldSourceProfileIds_BusinessName = this.FieldSourceProfileIds_BusinessName;
            context.FieldSourceProfileIds_BusinessPhoneNumber = this.FieldSourceProfileIds_BusinessPhoneNumber;
            context.FieldSourceProfileIds_EmailAddress = this.FieldSourceProfileIds_EmailAddress;
            context.FieldSourceProfileIds_FirstName = this.FieldSourceProfileIds_FirstName;
            context.FieldSourceProfileIds_Gender = this.FieldSourceProfileIds_Gender;
            context.FieldSourceProfileIds_HomePhoneNumber = this.FieldSourceProfileIds_HomePhoneNumber;
            context.FieldSourceProfileIds_LastName = this.FieldSourceProfileIds_LastName;
            context.FieldSourceProfileIds_MailingAddress = this.FieldSourceProfileIds_MailingAddress;
            context.FieldSourceProfileIds_MiddleName = this.FieldSourceProfileIds_MiddleName;
            context.FieldSourceProfileIds_MobilePhoneNumber = this.FieldSourceProfileIds_MobilePhoneNumber;
            context.FieldSourceProfileIds_PartyType = this.FieldSourceProfileIds_PartyType;
            context.FieldSourceProfileIds_PersonalEmailAddress = this.FieldSourceProfileIds_PersonalEmailAddress;
            context.FieldSourceProfileIds_PhoneNumber = this.FieldSourceProfileIds_PhoneNumber;
            context.FieldSourceProfileIds_ShippingAddress = this.FieldSourceProfileIds_ShippingAddress;
            context.MainProfileId = this.MainProfileId;
            #if MODULAR
            if (this.MainProfileId == null && ParameterWasBound(nameof(this.MainProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter MainProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProfileIdsToBeMerged != null)
            {
                context.ProfileIdsToBeMerged = new List<System.String>(this.ProfileIdsToBeMerged);
            }
            #if MODULAR
            if (this.ProfileIdsToBeMerged == null && ParameterWasBound(nameof(this.ProfileIdsToBeMerged)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileIdsToBeMerged which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.MergeProfilesRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate FieldSourceProfileIds
            var requestFieldSourceProfileIdsIsNull = true;
            request.FieldSourceProfileIds = new Amazon.CustomerProfiles.Model.FieldSourceProfileIds();
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_AccountNumber = null;
            if (cmdletContext.FieldSourceProfileIds_AccountNumber != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_AccountNumber = cmdletContext.FieldSourceProfileIds_AccountNumber;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_AccountNumber != null)
            {
                request.FieldSourceProfileIds.AccountNumber = requestFieldSourceProfileIds_fieldSourceProfileIds_AccountNumber;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_AdditionalInformation = null;
            if (cmdletContext.FieldSourceProfileIds_AdditionalInformation != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_AdditionalInformation = cmdletContext.FieldSourceProfileIds_AdditionalInformation;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_AdditionalInformation != null)
            {
                request.FieldSourceProfileIds.AdditionalInformation = requestFieldSourceProfileIds_fieldSourceProfileIds_AdditionalInformation;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_Address = null;
            if (cmdletContext.FieldSourceProfileIds_Address != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_Address = cmdletContext.FieldSourceProfileIds_Address;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_Address != null)
            {
                request.FieldSourceProfileIds.Address = requestFieldSourceProfileIds_fieldSourceProfileIds_Address;
                requestFieldSourceProfileIdsIsNull = false;
            }
            Dictionary<System.String, System.String> requestFieldSourceProfileIds_fieldSourceProfileIds_Attribute = null;
            if (cmdletContext.FieldSourceProfileIds_Attribute != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_Attribute = cmdletContext.FieldSourceProfileIds_Attribute;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_Attribute != null)
            {
                request.FieldSourceProfileIds.Attributes = requestFieldSourceProfileIds_fieldSourceProfileIds_Attribute;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_BillingAddress = null;
            if (cmdletContext.FieldSourceProfileIds_BillingAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_BillingAddress = cmdletContext.FieldSourceProfileIds_BillingAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_BillingAddress != null)
            {
                request.FieldSourceProfileIds.BillingAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_BillingAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_BirthDate = null;
            if (cmdletContext.FieldSourceProfileIds_BirthDate != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_BirthDate = cmdletContext.FieldSourceProfileIds_BirthDate;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_BirthDate != null)
            {
                request.FieldSourceProfileIds.BirthDate = requestFieldSourceProfileIds_fieldSourceProfileIds_BirthDate;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessEmailAddress = null;
            if (cmdletContext.FieldSourceProfileIds_BusinessEmailAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessEmailAddress = cmdletContext.FieldSourceProfileIds_BusinessEmailAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessEmailAddress != null)
            {
                request.FieldSourceProfileIds.BusinessEmailAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessEmailAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessName = null;
            if (cmdletContext.FieldSourceProfileIds_BusinessName != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessName = cmdletContext.FieldSourceProfileIds_BusinessName;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessName != null)
            {
                request.FieldSourceProfileIds.BusinessName = requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessName;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessPhoneNumber = null;
            if (cmdletContext.FieldSourceProfileIds_BusinessPhoneNumber != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessPhoneNumber = cmdletContext.FieldSourceProfileIds_BusinessPhoneNumber;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessPhoneNumber != null)
            {
                request.FieldSourceProfileIds.BusinessPhoneNumber = requestFieldSourceProfileIds_fieldSourceProfileIds_BusinessPhoneNumber;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_EmailAddress = null;
            if (cmdletContext.FieldSourceProfileIds_EmailAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_EmailAddress = cmdletContext.FieldSourceProfileIds_EmailAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_EmailAddress != null)
            {
                request.FieldSourceProfileIds.EmailAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_EmailAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_FirstName = null;
            if (cmdletContext.FieldSourceProfileIds_FirstName != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_FirstName = cmdletContext.FieldSourceProfileIds_FirstName;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_FirstName != null)
            {
                request.FieldSourceProfileIds.FirstName = requestFieldSourceProfileIds_fieldSourceProfileIds_FirstName;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_Gender = null;
            if (cmdletContext.FieldSourceProfileIds_Gender != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_Gender = cmdletContext.FieldSourceProfileIds_Gender;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_Gender != null)
            {
                request.FieldSourceProfileIds.Gender = requestFieldSourceProfileIds_fieldSourceProfileIds_Gender;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_HomePhoneNumber = null;
            if (cmdletContext.FieldSourceProfileIds_HomePhoneNumber != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_HomePhoneNumber = cmdletContext.FieldSourceProfileIds_HomePhoneNumber;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_HomePhoneNumber != null)
            {
                request.FieldSourceProfileIds.HomePhoneNumber = requestFieldSourceProfileIds_fieldSourceProfileIds_HomePhoneNumber;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_LastName = null;
            if (cmdletContext.FieldSourceProfileIds_LastName != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_LastName = cmdletContext.FieldSourceProfileIds_LastName;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_LastName != null)
            {
                request.FieldSourceProfileIds.LastName = requestFieldSourceProfileIds_fieldSourceProfileIds_LastName;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_MailingAddress = null;
            if (cmdletContext.FieldSourceProfileIds_MailingAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_MailingAddress = cmdletContext.FieldSourceProfileIds_MailingAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_MailingAddress != null)
            {
                request.FieldSourceProfileIds.MailingAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_MailingAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_MiddleName = null;
            if (cmdletContext.FieldSourceProfileIds_MiddleName != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_MiddleName = cmdletContext.FieldSourceProfileIds_MiddleName;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_MiddleName != null)
            {
                request.FieldSourceProfileIds.MiddleName = requestFieldSourceProfileIds_fieldSourceProfileIds_MiddleName;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_MobilePhoneNumber = null;
            if (cmdletContext.FieldSourceProfileIds_MobilePhoneNumber != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_MobilePhoneNumber = cmdletContext.FieldSourceProfileIds_MobilePhoneNumber;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_MobilePhoneNumber != null)
            {
                request.FieldSourceProfileIds.MobilePhoneNumber = requestFieldSourceProfileIds_fieldSourceProfileIds_MobilePhoneNumber;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_PartyType = null;
            if (cmdletContext.FieldSourceProfileIds_PartyType != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_PartyType = cmdletContext.FieldSourceProfileIds_PartyType;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_PartyType != null)
            {
                request.FieldSourceProfileIds.PartyType = requestFieldSourceProfileIds_fieldSourceProfileIds_PartyType;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_PersonalEmailAddress = null;
            if (cmdletContext.FieldSourceProfileIds_PersonalEmailAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_PersonalEmailAddress = cmdletContext.FieldSourceProfileIds_PersonalEmailAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_PersonalEmailAddress != null)
            {
                request.FieldSourceProfileIds.PersonalEmailAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_PersonalEmailAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_PhoneNumber = null;
            if (cmdletContext.FieldSourceProfileIds_PhoneNumber != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_PhoneNumber = cmdletContext.FieldSourceProfileIds_PhoneNumber;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_PhoneNumber != null)
            {
                request.FieldSourceProfileIds.PhoneNumber = requestFieldSourceProfileIds_fieldSourceProfileIds_PhoneNumber;
                requestFieldSourceProfileIdsIsNull = false;
            }
            System.String requestFieldSourceProfileIds_fieldSourceProfileIds_ShippingAddress = null;
            if (cmdletContext.FieldSourceProfileIds_ShippingAddress != null)
            {
                requestFieldSourceProfileIds_fieldSourceProfileIds_ShippingAddress = cmdletContext.FieldSourceProfileIds_ShippingAddress;
            }
            if (requestFieldSourceProfileIds_fieldSourceProfileIds_ShippingAddress != null)
            {
                request.FieldSourceProfileIds.ShippingAddress = requestFieldSourceProfileIds_fieldSourceProfileIds_ShippingAddress;
                requestFieldSourceProfileIdsIsNull = false;
            }
             // determine if request.FieldSourceProfileIds should be set to null
            if (requestFieldSourceProfileIdsIsNull)
            {
                request.FieldSourceProfileIds = null;
            }
            if (cmdletContext.MainProfileId != null)
            {
                request.MainProfileId = cmdletContext.MainProfileId;
            }
            if (cmdletContext.ProfileIdsToBeMerged != null)
            {
                request.ProfileIdsToBeMerged = cmdletContext.ProfileIdsToBeMerged;
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
        
        private Amazon.CustomerProfiles.Model.MergeProfilesResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.MergeProfilesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "MergeProfiles");
            try
            {
                #if DESKTOP
                return client.MergeProfiles(request);
                #elif CORECLR
                return client.MergeProfilesAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String FieldSourceProfileIds_AccountNumber { get; set; }
            public System.String FieldSourceProfileIds_AdditionalInformation { get; set; }
            public System.String FieldSourceProfileIds_Address { get; set; }
            public Dictionary<System.String, System.String> FieldSourceProfileIds_Attribute { get; set; }
            public System.String FieldSourceProfileIds_BillingAddress { get; set; }
            public System.String FieldSourceProfileIds_BirthDate { get; set; }
            public System.String FieldSourceProfileIds_BusinessEmailAddress { get; set; }
            public System.String FieldSourceProfileIds_BusinessName { get; set; }
            public System.String FieldSourceProfileIds_BusinessPhoneNumber { get; set; }
            public System.String FieldSourceProfileIds_EmailAddress { get; set; }
            public System.String FieldSourceProfileIds_FirstName { get; set; }
            public System.String FieldSourceProfileIds_Gender { get; set; }
            public System.String FieldSourceProfileIds_HomePhoneNumber { get; set; }
            public System.String FieldSourceProfileIds_LastName { get; set; }
            public System.String FieldSourceProfileIds_MailingAddress { get; set; }
            public System.String FieldSourceProfileIds_MiddleName { get; set; }
            public System.String FieldSourceProfileIds_MobilePhoneNumber { get; set; }
            public System.String FieldSourceProfileIds_PartyType { get; set; }
            public System.String FieldSourceProfileIds_PersonalEmailAddress { get; set; }
            public System.String FieldSourceProfileIds_PhoneNumber { get; set; }
            public System.String FieldSourceProfileIds_ShippingAddress { get; set; }
            public System.String MainProfileId { get; set; }
            public List<System.String> ProfileIdsToBeMerged { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.MergeProfilesResponse, MergeCPFProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Message;
        }
        
    }
}
